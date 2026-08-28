using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class UsuarioCamione
{
    public int IdUsuario { get; set; }

    public int IdCamion { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Camione IdCamionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
