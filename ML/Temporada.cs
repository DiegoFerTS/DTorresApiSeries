using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Temporada
    {
        public int? Id { get; set; }
        public Serie? Serie { get; set; }
        public int? NumeroTemporada { get; set; }
        public int? NumeroCapitulos { get; set; }
        public Estatus? Estatus { get; set; }
        public string? Sinopsis { get; set; }
        public string? Imagen { get; set; }
        public Informacion? Informacion { get; set; }
        public List<Temporada>? Temporadas { get; set; }
    }
}
