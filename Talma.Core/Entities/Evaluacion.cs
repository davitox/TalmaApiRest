using System;
using System.Collections.Generic;

namespace Talma.Core.Entities;

public partial class Evaluacion
{
    public decimal Id { get; set; }

    public decimal IdUsuario { get; set; }

    public decimal Nota1 { get; set; }

    public decimal Nota2 { get; set; }

    public decimal Nota3 { get; set; }

    public decimal Promedio { get; set; }

    public DateTime? FechaHoraRegistro { get; set; }

    public DateTime? FechaHoraModificacion { get; set; }
}
