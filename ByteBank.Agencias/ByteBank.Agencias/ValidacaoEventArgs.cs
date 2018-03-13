using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Agencias
{
    public class ValidacaoEventArgs : EventArgs
    {
        public string Texto { get; private set; }
        public bool Valido { get; set; }

        public ValidacaoEventArgs(string texto)
        {
            Texto = texto;
            Valido = true;
        }
    }
}
