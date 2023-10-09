using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RETO.CodeSkills.Application.Commands.DocenteC;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Application.Queries.Docentes;

namespace RETO._CodeSkill.API.Controllers.DocenteController
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocenteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DocenteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("ConsultarDocentes")]
        public async Task<IActionResult> ConsultarDocentes()
        {
            try
            {
                var result = await _mediator.Send(new ConsultarDocenteQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [HttpGet]
        [Route("ConsultarDocente/{id}")]
        public async Task<IActionResult> ConsultarDocenteByIdQuery(int id)
        {
            try
            {
                var resultado = await _mediator.Send(new ConsultarDocenteByIdQuery { Id = id });
                if (resultado == null)
                {
                    return NotFound($"La Identificacion {id} no existe en la base de datos.");
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Ha ocurrido un error al consultar el documento {id}. Detalle: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("CrearDocente")]
        public async Task<IActionResult> CrearDocente(CrearDocenteCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [HttpPut]
        [Route("EditarDocente")]
        public async Task<IActionResult> EditarDocente(EditarDocenteCommand command)
        {
            try
            {
                var result = await _mediator.Send(command);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Error", ex);
            }
        }

        [HttpDelete]
        [Route("EliminarDocente")]

        public async Task<IActionResult> EliminarDocente(int id)
        {
            try
            {
                var result = await _mediator.Send(new EliminarDocenteCommand { Id = id });

                if (result == false)
                {
                    return NotFound();
                }

                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(new { error = "Error al eliminar el docente", detail = ex.Message });
            }
        }
    }
}
