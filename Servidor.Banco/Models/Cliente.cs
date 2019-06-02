using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.Banco.Models
{
    public class Cliente
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public DateTime Nacimiento { get; set; }
    }
}
