using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorio_9_3
{
    internal class Trianglulo
    {
        private int lad1;
        private int lad2; 
        private int lad3;
        private string mensaje;


        public Trianglulo(int a, int b, int c)
        {
            lad1 = a;
            lad2 = b;
            lad3 = c;



                if (lad1 == lad2 || lad2 == lad3 || lad3 == lad1)
                {
                     mensaje = "Trianglulo isosseles";

                }
                else if (lad1 == lad2 && lad2 == lad3 && lad3 == lad1)
                {
                     mensaje = "triangulo Equilatero";
                }
                else if (lad1 != lad2 && lad2 != lad3 && lad3 != lad1)

                {
                     mensaje = "triangulo Escaleno";

                }


        }
        public string ObtenerMensaje()
        {
            return mensaje;
        }


    }
    
}
