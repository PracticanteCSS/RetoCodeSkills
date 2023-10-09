

namespace RETO.CodeSkills.Application.Dtos.DocenteDto
{
    public class DocenteDto
    {
        public int Id { get; set; }
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
}
