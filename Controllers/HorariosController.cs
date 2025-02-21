using System.Collections.Generic;
using ApiREST.Entities;
using ApiREST.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HorariosController : ControllerBase
    {
        private IHorariosService horariosService;

        public HorariosController(IHorariosService horarioService) { horariosService = horarioService; }

        [HttpGet("GetAll")]
        public ActionResult<IEnumerable<Horarios>> GetAll()
        {
            return Ok(horariosService.GetAll());
        }

        [HttpGet("GetHorario/{id:int}")]
        public ActionResult<Horarios> GetById(int id)
        {
            Horarios result = horariosService.GetById(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpPost("AddItem")]
        public ActionResult AddItem([FromBody] Horarios horario)
        {
            horariosService.PostHorarios(horario);
            horariosService.SaveChanges();

            return Ok();
        }

        [HttpPut("ChangeItem")]
        public ActionResult RemplaseItem(Horarios horario)
        {
            horariosService.PutHorarios(horario);
            horariosService.SaveChanges();

            return NotFound();
        }

        [HttpDelete("RemoveItem")]
        public ActionResult RemoveItem(Horarios horario)
        {
            horariosService.DeleteHorarios(horario);
            horariosService.SaveChanges();

            return Ok();
        }
    }
}