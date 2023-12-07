using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Capitulo
    {
        public int? Id { get; set; }
        public string? Titulo { get; set; }
        public string? UrlVideo { get; set; }
        public DateTime? Duracion { get; set; }
        public Temporada? Temporada { get; set; }
        public Informacion? Informacion { get; set; }
        public List<Capitulo>? Capitulos { get; set; }
    }
}
