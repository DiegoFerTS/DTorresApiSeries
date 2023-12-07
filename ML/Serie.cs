using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Serie
    {
        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public int? Temporadas { get; set; }
        public string? Sinopsis { get; set; }
        public Genero? Genero { get; set; }
        public TipoPublico? TipoPublico { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public Estatus? Estatus { get; set; }
        public string? Imagen { get; set; }
        public Informacion? Informacion { get; set; }
        public List<Serie>? Series { get; set; }
    }
}
