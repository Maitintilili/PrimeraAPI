using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Documento
{
    public int IdDocumento { get; set; }

    public int? IdTipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public virtual ICollection<Camionero> Camioneros { get; set; } = new List<Camionero>();

    public virtual TipoDocumento? IdTipoDocumentoNavigation { get; set; }
}
