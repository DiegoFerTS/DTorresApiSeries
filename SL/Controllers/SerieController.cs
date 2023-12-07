using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SerieController : ControllerBase
    {
        [EnableCors("API")]
        [Route("/SerieAdd")]
        [HttpPost]
        public ActionResult Add(ML.Serie serie)
        {
            ML.Informacion informacion = BL.Serie.Add(serie);

            if (informacion.Estatus == true)
            {
                return StatusCode(200, informacion);
            }
            else
            {
                return StatusCode(400, informacion);
            }
        }

        [EnableCors("API")]
        [Route("/SerieUpdate/{idSerie}")]
        [HttpPut]
        public ActionResult Update(int idSerie, [FromBody] ML.Serie serie)
        {
            serie.Id = idSerie;
            ML.Informacion informacion = BL.Serie.Update(serie);

            if (informacion.Estatus == true)
            {
                return StatusCode(200, informacion);
            }
            else
            {
                return StatusCode(400, informacion);
            }
        }

        [EnableCors("API")]
        [Route("/SerieDelete/{idSerie}")]
        [HttpDelete]
        public ActionResult Delete(int idSerie)
        {
            ML.Informacion informacion = BL.Serie.Delete(idSerie);

            if (informacion.Estatus == true)
            {
                return StatusCode(200, informacion);
            }
            else
            {
                return StatusCode(400, informacion);
            }
        }

        [EnableCors("API")]
        [Route("/SerieGetByTitle/{titulo?}")]
        [HttpGet]
        public ActionResult GetByTitle(string? titulo)
        {
            ML.Serie serie = BL.Serie.GetByTitle(titulo);

            if (serie.Informacion.Estatus == true)
            {
                return StatusCode(200, serie);
            }
            else
            {
                return StatusCode(400, serie.Informacion);
            }
        }

        [EnableCors("API")]
        [Route("/SerieGetById/{idSerie}")]
        [HttpGet]
        public ActionResult GetById(int idSerie)
        {
            ML.Serie serie = BL.Serie.GetById(idSerie);

            if (serie.Informacion.Estatus == true)
            {
                return StatusCode(200, serie);
            }
            else
            {
                return StatusCode(400, serie.Informacion);
            }
        }
    }
}
