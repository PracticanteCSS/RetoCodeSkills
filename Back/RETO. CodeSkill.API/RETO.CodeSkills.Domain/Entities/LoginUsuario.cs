

namespace RETO.CodeSkills.Domain.Entities
{
    public class LoginUsuario
    {
        public int IdUsuario { get; set; }

        public string NombreUsuario { get; set; } = null!;

        public string ContraseñaUsuario { get; set; } = null!;
    }

}
