using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Camionero
{
    public int IdCamionero { get; set; }

    public string? NombreCamionero { get; set; }

    public int? IdDocumento { get; set; }

    public virtual ICollection<Camione> Camiones { get; set; } = new List<Camione>();

    public virtual Documento? IdDocumentoNavigation { get; set; }

    public virtual ICollection<UsuarioCamionero> UsuarioCamioneros { get; set; } = new List<UsuarioCamionero>();
}
