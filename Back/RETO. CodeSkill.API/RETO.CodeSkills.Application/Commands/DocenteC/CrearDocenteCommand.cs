using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Application.Interfaces;
using RETO.CodeSkills.Domain.Entities;



namespace RETO.CodeSkills.Application.Commands.DocenteC
{
    public class CrearDocenteCommand : IRequest<DocenteDto>
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



    public class CrearDocenteCommandHandler : IRequestHandler<CrearDocenteCommand, DocenteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<CrearDocenteCommandHandler> _logger;



        public CrearDocenteCommandHandler(IApplicationDbContext context, IMapper mapper, ILogger<CrearDocenteCommandHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }



        public async Task<DocenteDto> Handle(CrearDocenteCommand request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("CrearDocenteCommandHandler started.");



            var docente = _mapper.Map<Docente>(request);
            var docenteExiste = await _context.Docentes.FirstOrDefaultAsync(x => x.IdentificacionDocente == request.IdentificacionDocente );
            if (docenteExiste != null)
            {
                throw new Exception("El docente ya esta registrado");
            }
            await _context.Docentes.AddAsync(docente);
            await _context.SaveChangesAsync(cancellationToken);



            _logger.LogDebug("CrearDocenteCommandHandler finished.");



            return _mapper.Map<DocenteDto>(docente);
        }
    }
}