using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Application.Interfaces;

namespace RETO.CodeSkills.Application.Commands.DocenteC
{
    public class EliminarDocenteCommand : IRequest<bool>
    {
        public int Id { get; set; }
    }

    public class EliminarDocenteCommandHandler : IRequestHandler<EliminarDocenteCommand, bool> 
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<EliminarDocenteCommandHandler> _logger;

        public EliminarDocenteCommandHandler(IApplicationDbContext context, ILogger<EliminarDocenteCommandHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<bool> Handle(EliminarDocenteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("EliminarDocenteCommandHandler started.");

            var docente = await _context.Docentes.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (docente == null)
            {
                _logger.LogError($"Identificacion {request.Id} no encontrado.");
                throw new KeyNotFoundException($"Identificacion {request.Id} no encontrado.");
            }

            _context.Docentes.Remove(docente);
            await _context.SaveChangesAsync(cancellationToken);

            _logger.LogDebug("EliminarDocenteCommandHandler finished.");

            return true;
        }
    }
}
