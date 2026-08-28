using System;
using System.Collections.Generic;

namespace PrimeraWebApi.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string NombreUsuario { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<UsuarioCamionero> UsuarioCamioneros { get; set; } = new List<UsuarioCamionero>();

    public virtual ICollection<UsuarioCamione> UsuarioCamiones { get; set; } = new List<UsuarioCamione>();
}
