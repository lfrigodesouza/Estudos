using ByteBank.Portal.Infraestrutura;
using ByteBank.Service;
using ByteBank.Service.Cambio;
using ByteBank.Portal.Filtros;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Service.Cartao;

namespace ByteBank.Portal.Controller
{
    public class CambioController : ControllerBase
    {
        private ICambioService _cambioService;
        private ICartaoService _cartaoService;

        public CambioController(ICambioService cambioService, ICartaoService cartaoService)
        {
            _cambioService = cambioService;
            _cartaoService = cartaoService;
        }

        [ApenasHorarioComercialFiltro]
        public string MXN()
        {
            var valorFinal = _cambioService.Calcular("MXN", "BRL", 1);

            return View(new
            {
                MoedaDestino = "",
                MoedaOrigem = "",
                ValorDestino = valorFinal,
                ValorOrigem = 1
            });

            //var textoPagina = View();

            //var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            //return textoResultado;
        }
        [ApenasHorarioComercialFiltro]
        public string USD()
        {
            var valorFinal = _cambioService.Calcular("USD", "BRL", 1);
            return View(new
            {
                MoedaDestino = "",
                MoedaOrigem = "",
                ValorDestino = valorFinal,
                ValorOrigem = 1
            });
            //var textoPagina = View();

            //var textoResultado = textoPagina.Replace("VALOR_EM_REAIS", valorFinal.ToString());

            //return textoResultado;
        }

        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino)
        {
            return Calculo("BRL", moedaDestino, 1);
        }
        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, decimal valor)
        {
            return Calculo("BRL", moedaDestino, valor);
        }
        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaDestino, string moedaOrigem)
        {
            return Calculo(moedaOrigem, moedaDestino, 1);
        }
        [ApenasHorarioComercialFiltro]
        public string Calculo(string moedaOrigem, string moedaDestino, decimal valor)
        {
            var valorFinal = _cambioService.Calcular(moedaOrigem, moedaDestino, valor);
            var cartaoPromocao = _cartaoService.ObterCartaoDeCreditoDeDestaque();
            var modelo = new
            {
                MoedaDestino = moedaDestino,
                MoedaOrigem = moedaOrigem,
                ValorDestino = valorFinal,
                ValorOrigem = valor,
                CartaoPromocao = cartaoPromocao
            };
            var textoPagina = View(modelo);

            return textoPagina;
        }
    }
}
