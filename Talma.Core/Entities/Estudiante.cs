using System;
using System.Collections.Generic;

namespace Talma.Core.Entities;

public partial class Estudiante
{
    public int Id { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string NombreCompleto { get; set; } = null!;

    public string NumDocumentoIdentidad { get; set; } = null!;

    public string? CorreoElectronico { get; set; }

    public DateTime FechaNacimiento { get; set; }

    public int Edad { get; set; }

    public DateTime? FechaHoraRegistro { get; set; }

    public DateTime? FechaHoraModificacion { get; set; }
}
