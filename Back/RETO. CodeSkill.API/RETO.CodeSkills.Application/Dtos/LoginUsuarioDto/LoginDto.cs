

namespace RETO.CodeSkills.Application.Dtos.LoginUsuarioDto
{
    public class LoginDto
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string ContraseñaUsuario { get; set; } = null!;
    }
}
