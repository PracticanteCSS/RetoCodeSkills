using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Application.Interfaces;
using RETO.CodeSkills.Domain.Entities;

namespace RETO.CodeSkills.Application.Commands.LoginC
{
    public class ActualizarLoginUsuarioCommand : IRequest<LoginUsuario>
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string ContraseñaUsuario { get; set; } = null!;
    }

    public class ActualizarLoginUsuarioCommandHandler : IRequestHandler<ActualizarLoginUsuarioCommand, LoginUsuario>
    {
        private readonly ILogger<ActualizarLoginUsuarioCommandHandler> _logger;
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ActualizarLoginUsuarioCommandHandler(ILogger<ActualizarLoginUsuarioCommandHandler> logger, IApplicationDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public async Task<LoginUsuario> Handle(ActualizarLoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var consultar = await _context.LoginUsuarios
                .FirstOrDefaultAsync(x => x.IdUsuario == request.IdUsuario,
                    cancellationToken);

            _mapper.Map(request, consultar);
            await _context.SaveChangesAsync(cancellationToken);
            return _mapper.Map<LoginUsuario>(consultar);
        }
    }

}
