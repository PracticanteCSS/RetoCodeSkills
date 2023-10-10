using AutoMapper;
using RETO.CodeSkills.Application.Commands.LoginC;
using RETO.CodeSkills.Domain.Entities;


namespace RETO.CodeSkills.Application.Mappings.LoginUsuarioM
{
    internal class LoginUsuarioMapping : Profile
    {
        public LoginUsuarioMapping() 
        {
            CreateMap<CrearLoginUsuarioCommand, LoginUsuario>();
            CreateMap<ActualizarLoginUsuarioCommand, LoginUsuario>();
        }
    }
}
