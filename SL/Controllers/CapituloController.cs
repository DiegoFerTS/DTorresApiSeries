using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CapituloController : ControllerBase
    {
        [EnableCors("API")]
        [Route("/CapituloAdd")]
        [HttpPost]
        public ActionResult Add(ML.Capitulo capitulo)
        {
            ML.Informacion informacion = BL.Capitulo.Add(capitulo);

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
        [Route("/CapituloUpdate/{idCapitulo}")]
        [HttpPut]
        public ActionResult Update(int idCapitulo, [FromBody] ML.Capitulo capitulo)
        {
            capitulo.Id = idCapitulo;
            ML.Informacion informacion = BL.Capitulo.Update(capitulo);

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
        [Route("/CapituloDelete/{idCapitulo}")]
        [HttpDelete]
        public ActionResult Delete(int idCapitulo)
        {
            ML.Informacion informacion = BL.Capitulo.Delete(idCapitulo);

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
        [Route("/CapituloGetByIdTemporada/{idTemporada}")]
        [HttpGet]
        public ActionResult GetByIdTemporada(int idTemporada)
        {
            ML.Capitulo capitulo = BL.Capitulo.GetByIdTemporada(idTemporada);

            if (capitulo.Informacion.Estatus == true)
            {
                return StatusCode(200, capitulo);
            }
            else
            {
                return StatusCode(400, capitulo.Informacion);
            }
        }

        [EnableCors("API")]
        [Route("/CapituloGetById/{idCapitulo}")]
        [HttpGet]
        public ActionResult GetById(int idCapitulo)
        {
            ML.Capitulo capitulo = BL.Capitulo.GetById(idCapitulo);

            if (capitulo.Informacion.Estatus == true)
            {
                return StatusCode(200, capitulo);
            }
            else
            {
                return StatusCode(400, capitulo.Informacion);
            }
        }
    }
}
