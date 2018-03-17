using ByteBank.Portal.Controller;
using ByteBank.Portal.Infraestrutura.IoC;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Service.Cartao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public class WebApplication
    {
        public readonly string[] _prefixos;

        private readonly IContainer _container = new ContainerSimples();


        public WebApplication(string[] prefixos)
        {
            _prefixos = prefixos ?? throw new ArgumentNullException(nameof(prefixos));
            Configurar();
        }
        public void Iniciar()
        {
            while (true)
            {
                ManipularRequisicao();
            }
        }
        private void Configurar()
        {
            //_container.Registrar(typeof(ICambioService), typeof(CambioTestService));
            //_container.Registrar(typeof(ICartaoService), typeof(CartaoTestService));

            _container.Registrar<ICambioService, CambioTestService>();
            _container.Registrar<ICartaoService, CartaoTestService>();

        }
        private void ManipularRequisicao()
        {
            var httpListener = new HttpListener();
            foreach (var prefixo in _prefixos)
            {
                httpListener.Prefixes.Add(prefixo);
            }
            httpListener.Start();
            var contexto = httpListener.GetContext();
            var requisicao = contexto.Request;
            var resposta = contexto.Response;

            var path = requisicao.Url.PathAndQuery;

            if (Utilidades.Arquivo(path))
            {
                var manipulador = new ManipuladorRequisicaoArquivo();
                manipulador.Manipular(resposta, path);
            }
            else
            {
                var manipulador = new ManipuladorRequisicaoController(_container);
                manipulador.Manipular(resposta, path);
            }

            httpListener.Stop();
        }
    }
}
