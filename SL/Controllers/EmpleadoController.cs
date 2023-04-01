using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace SL.Controllers
{
    public class EmpleadoController : Controller
    {
        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/GetAll")]
        public ActionResult GetAll()
        {
            ML.Result result = BL.Empleado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }
        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Add")]
        public ActionResult Add([FromBody]ML.Empleado empleado)
        {
            
            ML.Result result = BL.Empleado.Add(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [HttpPost]
        [Route("api/Empleado/Update")]

        public ActionResult Update([FromBody]ML.Empleado empleado)
        {
            ML.Result result = BL.Empleado.Update(empleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/Delete/{idEmpleado}")]
        public ActionResult Delete(int IdEmpleado)
        {
            ML.Result result = BL.Empleado.Delete(IdEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }

        }

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/GetById/{idEmpleado}")]
        public ActionResult GetById(int idEmpleado)
        {
            ML.Result result = BL.Empleado.GetById(idEmpleado);

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [EnableCors("API")]
        [HttpGet]
        [Route("api/Empleado/EstadoGetAll")]
        public ActionResult EstadoGetAll()
        {
            ML.Result result = BL.Estado.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

    }
}
