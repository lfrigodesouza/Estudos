using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Service.Cartao
{
    public class CartaoTestService : ICartaoService
    {
        public string ObterCartaoDeCreditoDeDestaque()
        {
            return "ByteBank Card Power Bazuca";
        }

        public string ObterCartaoDeDebitoDeDestaque()
        {
            return "ByteBank Debitator Card";
        }
    }
}
