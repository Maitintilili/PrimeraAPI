using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class UsuarioCamionero
{
    public int IdUsuario { get; set; }

    public int IdCamionero { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Camionero IdCamioneroNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
