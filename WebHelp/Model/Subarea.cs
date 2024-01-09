using System;
using System.Collections.Generic;

namespace WebHelp.Model;

public partial class Subarea
{
    public int IdSubarea { get; set; }

    public string? Nombre { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual ICollection<Empleado> Empleados { get; } = new List<Empleado>();
}
