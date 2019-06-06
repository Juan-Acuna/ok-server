using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.OKCasa.Models
{
    public class Inspeccion
    {
        [Key]
        public int Id_inspeccion { get; set; }
        public DateTime Fecha_visita { get; set; }
        public String Observaciones { get; set; }
        public int Monto { get; set; }
        public int Solicitud { get; set; }
    }
}
