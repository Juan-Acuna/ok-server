using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.OKCasa.Models
{
    public class Usuario
    {
        [Key]
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Clave { get; set; }
        public String Email { get; set; }
        public DateTime Fecha_nac { get; set; }
        public int Id_tipo { get; set; }
    }
}
