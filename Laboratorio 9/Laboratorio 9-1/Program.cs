internal class Program
{
    private static void Main(string[] args)
    {
        double precioP;
        int metodoDePago;

        

        Console.WriteLine("Ingrese el precio del producto :");
        precioP = double.Parse(Console.ReadLine());

        while (precioP >= 0)

        {
            Console.WriteLine("\n Ingrese su metodo de pago ");
            Console.WriteLine("\n Opcion 1: efectivo ");
            Console.WriteLine("\n Opcion 2: tarjeta ");
            //  modoPago= Console.ReadLine();
            //Console.ReadLine());
            metodoDePago = int.Parse(Console.ReadLine());



            if (metodoDePago == 1) 
            {
                Console.WriteLine("Entregue el dinero a la cajera  :");
                Console.WriteLine($"Total a pagar: ${precioP}");

            }
            else if (metodoDePago == 2)
            {
                Console.WriteLine("Ingrese los 16 digitos del Numero de Cuenta  :");
                string numeroCuenta = Console.ReadLine();
                //string numeroCuenta = Console.ReadLine();

                if (numeroCuenta.Length == 16 )
                {
                    Console.WriteLine("\nPago procesado exitosamente");
                    Console.WriteLine($"Total pagado: ${precioP}");
                }
                else
                {
                    Console.WriteLine("\n Ingrese los 16 digitos del Numero de Cuenta ");
                }


            }



        }

    }
 }
