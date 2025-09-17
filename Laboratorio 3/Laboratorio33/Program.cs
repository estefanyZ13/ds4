internal class Program
{
    private static void Main(string[] args)
    {
        int  alturaRectangulo, baseRectangulo, perimetro;


        Console.Write("Introduce la altura del restangulo:");
        alturaRectangulo = Convert.ToInt32(Console.ReadLine());

        Console.Write("Introduce la base del restangulo:");
        baseRectangulo = Convert.ToInt32(Console.ReadLine());


        perimetro = 2*(alturaRectangulo +baseRectangulo);

        Console.WriteLine("La suma de {0} y {1} es {2}:", alturaRectangulo, baseRectangulo, perimetro);

    }
}