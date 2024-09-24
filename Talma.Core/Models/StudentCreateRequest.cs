using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talma.Core.Models
{
    public class StudentCreateRequest
    {
        public string Nombres { get; set; }

        public string Apellidos { get; set; } 

        public string NumDocumentoIdentidad { get; set; }

        public string? CorreoElectronico { get; set; }

        public DateTime FechaNacimiento { get; set; }
    }
}
