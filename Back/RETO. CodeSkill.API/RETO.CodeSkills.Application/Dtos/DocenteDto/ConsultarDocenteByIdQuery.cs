
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RETO.CodeSkills.Application.Interfaces;

namespace RETO.CodeSkills.Application.Dtos.DocenteDto
{
    public class ConsultarDocenteByIdQuery : IRequest<DocenteDto>
    {
        public int Id { get; set; }
    }

    public class ConsultarDocenteByIdQueryHandler : IRequestHandler<ConsultarDocenteByIdQuery, DocenteDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<ConsultarDocenteByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public ConsultarDocenteByIdQueryHandler(IApplicationDbContext context, ILogger<ConsultarDocenteByIdQueryHandler> logger, IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<DocenteDto> Handle(ConsultarDocenteByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogDebug("ConsultarDocenteByIdQueryHandler started");

            var docente = await _context.Docentes.FirstOrDefaultAsync(x => x.Id == request.Id);
            var docenteDto = _mapper.Map<DocenteDto>(docente);

            _logger.LogDebug("ConsultarDocenteByIdQueryHandler finished");
            return docenteDto;
        }
    }
}
