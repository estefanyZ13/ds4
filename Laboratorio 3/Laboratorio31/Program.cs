internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, CalculosMatematicos;

        Console.Write("Introduce el primer numero:");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.Write("Introduce el segunda numero:");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos =( (primerNumero + segundoNumero) * (primerNumero - segundoNumero) );

        Console.WriteLine("el culos Matematicosde {0} y {1} es {2}:", primerNumero, segundoNumero, CalculosMatematicos);
    
    }
}