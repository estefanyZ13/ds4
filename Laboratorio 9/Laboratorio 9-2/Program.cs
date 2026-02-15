using Laboratorio_9_2;

internal class Program
{
    private static void Main(string[] args)
    {
        Cargar obj = new Cargar();
        obj.Operacion();

        Console.WriteLine("\nPresiona cualquier tecla para salir...");
        Console.ReadKey();

    }
}