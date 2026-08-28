using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Camione
{
    public int IdCamion { get; set; }

    public string? MatriculaCamion { get; set; }

    public int? IdCamionero { get; set; }

    public virtual Camionero? IdCamioneroNavigation { get; set; }

    public virtual ICollection<UsuarioCamione> UsuarioCamiones { get; set; } = new List<UsuarioCamione>();

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
