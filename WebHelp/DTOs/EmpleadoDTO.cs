namespace WebHelp.DTOs
{
    public class EmpleadoDTO
    {
        public int IdEmpleado { get; set; }

        public string? Nombres { get; set; }

        public string? Apellidos { get; set; }

        public string? TipoDocumento { get; set; }

        public string? NumeroDocumento { get; set; }

        public int? IdPais{ get; set; }
        public string? NombrePais { get; set; }
        public int? IdArea { get; set; }
        public string? NombreArea { get; set; }
        public int? IdSubarea { get; set; }
        public string? NombreSubarea { get; set; }

        public string? FechaContrato { get; set; }
    }
}
