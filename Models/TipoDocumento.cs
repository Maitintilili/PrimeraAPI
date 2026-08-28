using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class TipoDocumento
{
    public int IdTipoDocumento { get; set; }

    public string? NombreTipoDocumento { get; set; }

    public virtual ICollection<Documento> Documentos { get; set; } = new List<Documento>();
}
