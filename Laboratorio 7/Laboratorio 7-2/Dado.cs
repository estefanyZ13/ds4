using System;

namespace Laboratorio_7_1
{
    internal class Dado
    {
        private int valor;
        private static Random aleatorio = new Random();

        public void Tirar()
        {
            valor = aleatorio.Next(1, 7); // valores entre 1 y 6
        }

        public void Imprimir()
        {
            Console.WriteLine("El valor del dado es: " + valor);
        }

        public int RetornarValor()
        {
            return valor;
        }
    }
}
