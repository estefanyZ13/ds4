using Laboratorio_8_4;

internal class Program
{

    private static void Main(string[] args)
    {
        Empleado empleado = new Empleado();
        empleado.Nombre = "John Doe";
        Console.WriteLine($"El saldo del empleado :{empleado.Nombre}");

        CuentaBancaria cta = new CuentaBancaria();
        cta.Saldo = 100;
        Console.WriteLine($"el saldo del emplado:{cta.Saldo}");

        Cobertura c = new Cobertura(5);
        Console.WriteLine($"Con una cobertura de :{ c.Radio}");
        
    }
}