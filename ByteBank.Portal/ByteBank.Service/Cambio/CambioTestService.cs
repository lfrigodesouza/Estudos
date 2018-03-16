using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Service.Cambio
{
    public class CambioTestService : ICambioService
    {
        private readonly Random _rnd = new Random();
        public decimal Calcular(string moedaOrigem, string moedaDestino, decimal valor)
        {
            return (decimal)_rnd.NextDouble();
        }
    }
}
