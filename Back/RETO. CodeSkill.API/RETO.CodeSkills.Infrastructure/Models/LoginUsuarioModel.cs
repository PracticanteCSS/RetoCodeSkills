using System;
using System.Collections.Generic;

namespace RETO._CodeSkill.API.Models;

public partial class LoginUsuariomodels
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string ContraseñaUsuario { get; set; } = null!;
}
