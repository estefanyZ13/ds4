using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_8_4
{
    internal class Cobertura
    {
        private double radio;

        public Cobertura(double radio)
        { 
        this.radio = radio; 
        }

        public double Radio
        { 
        get { return radio; }   
        }
    }
}
