



    internal class Program
    {
        private static void Main(string[] args)
        {
            // Crear la lista de estudiantes
            List<Estudiante> estudiantes = new List<Estudiante>
            {
                new Estudiante { Nombre = "Ana", Edad = 12 },
                new Estudiante { Nombre = "Juan", Edad = 10 },
                new Estudiante { Nombre = "Sofia", Edad = 11 }
            };

            // Recorrer e imprimir los datos
            foreach (Estudiante estudiante in estudiantes)
            {
                Console.WriteLine("Nombre: " + estudiante.Nombre + ", Edad: " + estudiante.Edad);
            }
        }
    }

    // Clase Estudiante declarada FUERA del Main
    class Estudiante
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
    }

