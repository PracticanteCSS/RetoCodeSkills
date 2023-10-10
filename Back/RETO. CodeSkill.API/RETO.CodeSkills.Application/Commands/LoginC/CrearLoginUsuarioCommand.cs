

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Interfaces;
using RETO.CodeSkills.Domain.Entities;

namespace RETO.CodeSkills.Application.Commands.LoginC
{
    public class CrearLoginUsuarioCommand : IRequest<LoginUsuario>
    {
        public string NombreUsuario { get; set; } = null!;

        public string ContraseñaUsuario { get; set; } = null!;
    }

    public class CrearLoginUsuarioCommandHandler : IRequestHandler<CrearLoginUsuarioCommand, LoginUsuario> 
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CrearLoginUsuarioCommandHandler> _logger;

        public CrearLoginUsuarioCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CrearLoginUsuarioCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<LoginUsuario> Handle(CrearLoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("CrearLoginUsuarioCommandHandler Started");

            Random random = new Random();
            var caracteresPermitidos = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            char[] caracteres = new char[6];

            for (int i = 0; i < 6; i++)
            {
                caracteres[i] = caracteresPermitidos[random.Next(caracteresPermitidos.Length)];
            }
            var contrasena = new string(caracteres);
            var login = new LoginUsuario()
            {
                NombreUsuario = request.NombreUsuario,
                ContraseñaUsuario = request.ContraseñaUsuario
            };
            var DatoExistente = await _context.LoginUsuarios.FirstOrDefaultAsync(x => x.NombreUsuario == request.NombreUsuario && x.ContraseñaUsuario == request.ContraseñaUsuario);

            if (DatoExistente != null)
            {
                throw new Exception("El usuario ya se encuentra registrado");
            }

            _context.LoginUsuarios.Add(login);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("CrearLoginUsuarioCommandHandler Finished");

            return login;
            
        }
    }
}
