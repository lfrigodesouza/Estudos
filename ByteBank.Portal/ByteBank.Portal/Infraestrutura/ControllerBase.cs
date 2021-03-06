﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ByteBank.Portal.Infraestrutura
{
    public abstract class ControllerBase
    {
        protected string View([CallerMemberName]string nomeArquivo = null)
        {
            var type = GetType();
            var diretorioNome = type.Name.Replace("Controller", "");
            var nomeCompletoResource = $"ByteBank.Portal.View.{diretorioNome}.{nomeArquivo}.html";
            var assembly = Assembly.GetExecutingAssembly();
            var streamResource = assembly.GetManifestResourceStream(nomeCompletoResource);

            var streamLeitura = new StreamReader(streamResource);
            var textopagina = streamLeitura.ReadToEnd();

            return textopagina;
        }

        protected string View(object modelo, [CallerMemberName]string nomeArquivo = null)
        {
            var viewBruta = View(nomeArquivo);
            var todasAsPropiedadesDoModelo = modelo.GetType().GetProperties();

            var regex = new Regex("\\{{(.*?)\\}}");
            var viewProcessada = regex.Replace(viewBruta, (match) =>
            {
                var nomePropriedade = match.Groups[1].Value;
                var propriedade = todasAsPropiedadesDoModelo.Single(_ => _.Name == nomePropriedade);
                var valorBruto = propriedade.GetValue(modelo);
                return valorBruto?.ToString();
            });

            return viewProcessada;
        }
    }
}
