using System;

namespace Parcial3
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int AnioPublicacion { get; set; }
        public string RevistaCientifica { get; set; }
        public string DOI { get; set; }
        public string Resumen { get; set; }
        public string PalabrasClave { get; set; }
        public string UbicacionFisica { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}