using Laboratorio_9_3;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Ingrese el primer lado: ");
        int lado1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el segundo lado: ");
        int lado2 = Convert.ToInt32(Console.ReadLine());

        Console.Write("Ingrese el tercer lado: ");
        int lado3 = Convert.ToInt32(Console.ReadLine());

        Trianglulo miTriangulo = new Trianglulo(lado1, lado2, lado3);

        // Retornar y mostrar el mensaje
        string resultado = miTriangulo.ObtenerMensaje();
        Console.WriteLine(resultado);

    }
}