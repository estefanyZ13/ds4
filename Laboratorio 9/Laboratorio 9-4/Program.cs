using Laboratorio_9_4;

internal class Program
{
    private static void Main(string[] args)
    {
        Aleatorios generador = new Aleatorios();

        Console.WriteLine("NÚMEROS ALEATORIOS");
       

       
        Console.WriteLine("1. Generar un número entre 1 y 100:");
        int numero = generador.GenerarNumero(1, 100);
        Console.WriteLine($"   Número generado: {numero}\n");

       
        Console.WriteLine("2. Generar un número entre 50 y 200:");
        int numero2 = generador.GenerarNumero(50, 200);
        Console.WriteLine($"   Número generado: {numero2}\n");

       
        Console.WriteLine("3. Generar arreglo de 10 números entre 1 y 50:");
        int[] arreglo1 = generador.GenerarArreglo(1, 50, 10);
        Console.Write("   ");
        generador.MostrarArreglo(arreglo1);
        Console.WriteLine();

      
        Console.WriteLine("4. Generar arreglo de 15 números entre 100 y 500:");
        int[] arreglo2 = generador.GenerarArreglo(100, 500, 15);
        Console.Write("   ");
        generador.MostrarArreglo(arreglo2);

     
        Console.ReadKey();
    }
}