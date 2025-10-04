using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Laboratorio_8_8
{
    abstract class ClaseAbstracta
    {
        protected abstract string tomarValor();
        public abstract string prefixValor(string prefix);

        public void printOut()
        {
            Console.WriteLine(tomarValor());
        }
    }
}

