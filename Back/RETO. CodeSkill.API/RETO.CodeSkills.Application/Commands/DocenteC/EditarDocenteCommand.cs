

using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Application.Interfaces;

namespace RETO.CodeSkills.Application.Commands.DocenteC
{
    public class EditarDocenteCommand : IRequest<DocenteDto>
    {
        
        public int IdentificacionDocente { get; set; }

        public string TipoIdentificacionDocente { get; set; } = null!;

        public string NombreDocente { get; set; } = null!;

        public string ApellidoDocente { get; set; } = null!;

        public string CorreoElectronicoDocente { get; set; } = null!;

        public string TelefonoCelularDocente { get; set; } = null!;

        public string NumeroContratoDocente { get; set; } = null!;

        public string CiudadResidenciaDocente { get; set; } = null!;

        public string EscalafonTecnicoDocente { get; set; } = null!;

        public string EscalafonExtensionDocente { get; set; } = null!;
    }

    public class EditarDocenteCommandHandler : IRequestHandler<EditarDocenteCommand, DocenteDto> 
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<EditarDocenteCommandHandler> _logger;
        private readonly IMapper _mapper;

        public EditarDocenteCommandHandler(IApplicationDbContext context, ILogger<EditarDocenteCommandHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DocenteDto> Handle(EditarDocenteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("EditarDocenteCommandHandler started. ");
            var docente = await _context.Docentes.FirstOrDefaultAsync(x => x.IdentificacionDocente == request.IdentificacionDocente, cancellationToken);
            {
                _mapper.Map(request, docente);
            }

            await _context.SaveChangesAsync(cancellationToken);

            var resultado = _mapper.Map<DocenteDto>(docente);

            _logger.LogDebug("EditarDocenteCommandHandler finished. ");

            return resultado;
        }
    }
    
}
