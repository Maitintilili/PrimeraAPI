using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Viaje
{
    public int IdViaje { get; set; }

    public int? IdCamion { get; set; }

    public string? Origen { get; set; }

    public string? Destino { get; set; }

    public int? TotalKilometros { get; set; }

    public DateOnly? Fecha { get; set; }

    public int? IdMaterial { get; set; }

    public decimal? CantidadMaterial { get; set; }

    public virtual Camione? IdCamionNavigation { get; set; }

    public virtual Materiale? IdMaterialNavigation { get; set; }

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
