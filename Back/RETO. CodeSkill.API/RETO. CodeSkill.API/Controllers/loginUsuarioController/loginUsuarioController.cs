using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RETO.CodeSkills.Application.Commands.LoginC;
using RETO.CodeSkills.Application.Interfaces;
using RETO.CodeSkills.Domain.Entities;
using System.Threading;

namespace RETO._CodeSkill.API.Controllers.loginUsuarioController
{
    [Route("api/[controller]")]
    [ApiController]
    public class loginUsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IApplicationDbContext _context;

        public loginUsuarioController(IMediator mediator, IApplicationDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost("CrearLoginUsuario")]
        public async Task<IActionResult> CrearLoginUsuario(CrearLoginUsuarioCommand request)
        {
            try
            {
                var resultado = await _mediator.Send(request);
                if (resultado == null)
                {
                    return NotFound();
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error al crear el usuario. Detalle: {ex.Message}");
            }

        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] LoginUsuario request, CancellationToken cancellationToken)
        {
            if (request == null)
                return BadRequest();
            await _context.LoginUsuarios.AddAsync(request);
            await _context.SaveChangesAsync(cancellationToken);
            return Ok(new { Message = "Usuario Registrado con Exito!" });
        }

        [HttpPost("Autenticacion")]

        public async Task<IActionResult> Autenticacion([FromBody] LoginUsuario request)
        {
            if (request == null)
            {
                return BadRequest(new { message = "No se encontró registro"});
            }
            var login = await _context.LoginUsuarios.FirstOrDefaultAsync(x => x.NombreUsuario == request.NombreUsuario && x.ContraseñaUsuario == request.ContraseñaUsuario);
            if (login == null)
                return NotFound(new { Message = "Usuario no encontrado" });
            return Ok(new
            {
                Message = "Login Exitoso!"
            });
        }

        [HttpPut("ActualizarLoginUsuario")]
        public async Task<IActionResult> ActualizarLoginUsuario(ActualizarLoginUsuarioCommand request)
        {
            try
            {
                var resultado = await _mediator.Send(request);
                if (resultado == null)
                {
                    return NotFound();
                }
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ha ocurrido un error al actualizar el usuario. Detalle: {ex.Message}");
            }
        }
    }
}
