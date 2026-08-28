using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Materiale
{
    public int IdMaterial { get; set; }

    public string? NombreMaterial { get; set; }

    public virtual ICollection<Viaje> Viajes { get; set; } = new List<Viaje>();
}
