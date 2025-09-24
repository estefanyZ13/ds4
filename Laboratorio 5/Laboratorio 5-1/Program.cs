
internal class PruebaVector1
{
    static void Main(string[] args)
    {
        PruebaVector1 pv = new PruebaVector1();
        pv.Cargar();
        pv.Imprimir();

    }
    private int[] sueldos;

    
    public void Cargar()

    {
        sueldos = new int[6];//inicializacion
        for (int f = 1; f <= 5; f++)
        {

            Console.WriteLine("Ingrese sueldo del opererio" + f + ":");
            String linea;
            linea = Console.ReadLine();
            sueldos[f] = int.Parse(linea);

        }


    }


    public void Imprimir()
    {
        Console.WriteLine("Los 5 sueldos de los operarios son:\n");
        for (int f = 0; f <= 5; f++)
        {
            Console.WriteLine("Resultado[" + f + "]: " + sueldos[f]);
        }
        Console.ReadKey();
    }
}

