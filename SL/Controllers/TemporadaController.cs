using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemporadaController : ControllerBase
    {
        [EnableCors("API")]
        [Route("/TemporadaAdd")]
        [HttpPost]
        public ActionResult Add(ML.Temporada temporada)
        {
            ML.Informacion informacion = BL.Temporada.Add(temporada);

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
        [Route("/TemporadaUpdate/{idTemporada}")]
        [HttpPut]
        public ActionResult Update(int idTemporada, [FromBody] ML.Temporada temporada)
        {
            temporada.Id = idTemporada;
            ML.Informacion informacion = BL.Temporada.Update(temporada);

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
        [Route("/TemporadaDelete/{idTemporada}")]
        [HttpDelete]
        public ActionResult Delete(int idTemporada)
        {
            ML.Informacion informacion = BL.Temporada.Delete(idTemporada);

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
        [Route("/TemporadaGetByIdSerie/{idSerie}")]
        [HttpGet]
        public ActionResult GetByIdSerie(int idSerie)
        {
            ML.Temporada temporada = BL.Temporada.GetByIdSerie(idSerie);

            if (temporada.Informacion.Estatus == true)
            {
                return StatusCode(200, temporada);
            }
            else
            {
                return StatusCode(400, temporada.Informacion);
            }
        }

        [EnableCors("API")]
        [Route("/TemporadaGetById/{idTemporada}")]
        [HttpGet]
        public ActionResult GetById(int idTemporada)
        {
            ML.Temporada temporada = BL.Temporada.GetById(idTemporada);

            if (temporada.Informacion.Estatus == true)
            {
                return StatusCode(200, temporada);
            }
            else
            {
                return StatusCode(400, temporada.Informacion);
            }
        }
    }
}
