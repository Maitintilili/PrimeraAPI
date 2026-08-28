using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class VistaCamionerosMasDinero
{
    public int IdCamionero { get; set; }

    public string? NombreCamionero { get; set; }

    public decimal? TotalGenerado { get; set; }
}
