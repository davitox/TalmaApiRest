using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talma.Core.Entities;

namespace Talma.Core.Models
{
    public class Response
    {
        public Response()
        {
        }

        public Response(int code, string msg)
        {
            this.code = code;
            this.msg = msg;
        }

        public Response(int code, string msg, List<Estudiante> data) : this(code, msg)
        {
            this.data = data;
        }

        public int code { get; set; }
        public string msg { get; set; }
        public List<Estudiante> data { get; set; }

    }
}
