using System;
using System.Collections.Generic;

namespace WebHelp.Model;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? TipoDocumento { get; set; }

    public string? NumeroDocumento { get; set; }

    public DateTime? FechaContrato { get; set; }

    public string? Pais { get; set; }

    public int? IdArea { get; set; }

    public int? IdSubarea { get; set; }

    public DateTime? FechaCreacion { get; set; }

    public virtual Area? IdAreaNavigation { get; set; }

    public virtual Subarea? IdSubareaNavigation { get; set; }
}
