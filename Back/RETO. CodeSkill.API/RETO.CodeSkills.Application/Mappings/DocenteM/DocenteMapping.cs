using AutoMapper;
using RETO.CodeSkills.Application.Commands.DocenteC;
using RETO.CodeSkills.Application.Dtos.DocenteDto;
using RETO.CodeSkills.Domain.Entities;


namespace RETO.CodeSkills.Application.Mappings.DocenteM
{
    public class DocenteMapping : Profile
    {
        public DocenteMapping() 
        { 
            CreateMap<Docente, DocenteDto>();
            CreateMap<CrearDocenteCommand, Docente>();
            CreateMap<EditarDocenteCommand, Docente>();
        }
    }
}
