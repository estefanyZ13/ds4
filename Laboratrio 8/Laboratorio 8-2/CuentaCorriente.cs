using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_8_2
{
    internal class CuentaCorriente : Cuenta
    {

        public CuentaCorriente(string prmIdCuenta):base(prmIdCuenta)        
        { 
        
        }
        public override void CalcularIntereses()
        {
            System.Console.WriteLine("CuentaCorriente.CalcularInterese()  efectuando para" + "la cuenta {0}",getIdCuenta ());
        }
    }
}
