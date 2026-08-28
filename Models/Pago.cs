using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public int? IdViaje { get; set; }

    public decimal? TotalPagar { get; set; }

    public decimal? MontoPagado { get; set; }

    public decimal? MontoPendiente { get; set; }

    public DateOnly? Fecha { get; set; }

    public virtual Viaje? IdViajeNavigation { get; set; }
}
