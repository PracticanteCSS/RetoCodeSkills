using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Application.Interfaces;

namespace RETO.CodeSkills.Application.Queries.Docentes
{
    public class ConsultarDocenteQuery : IRequest<List<DocenteDto>>
    {
    }

    public class ConsultarDocenteQueryHandler : IRequestHandler<ConsultarDocenteQuery, List<DocenteDto>> 
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ConsultarDocenteQueryHandler> _logger;

        public ConsultarDocenteQueryHandler(IApplicationDbContext context, ILogger<ConsultarDocenteQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<List<DocenteDto>> Handle(ConsultarDocenteQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("ConsultarDocenteQueryHandler started. ");

            var docentes = await _context.Docentes.Select(x => new DocenteDto()
            {
                 Id = x.Id,
                 IdentificacionDocente = x.IdentificacionDocente,
                 TipoIdentificacionDocente = x.TipoIdentificacionDocente,
                 NombreDocente = x.NombreDocente,
                 ApellidoDocente = x.ApellidoDocente,
                 CorreoElectronicoDocente = x.CorreoElectronicoDocente,
                 TelefonoCelularDocente = x.TelefonoCelularDocente,
                 NumeroContratoDocente = x.NumeroContratoDocente,
                 CiudadResidenciaDocente = x.CiudadResidenciaDocente,
                 EscalafonTecnicoDocente = x.EscalafonTecnicoDocente,
                 EscalafonExtensionDocente = x.EscalafonExtensionDocente
      
            }).ToListAsync(cancellationToken);

            _logger.LogDebug("ConsultarDocenteQueryHandler finished. ");

            return docentes;
        }
    }
}
