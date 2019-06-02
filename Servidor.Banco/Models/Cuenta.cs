using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.Banco.Models
{
    public class Cuenta
    {
        public int Id_cuenta { get; set; }
        public String Clave { get; set; }
        public int Fondos { get; set; }
        public String Rut { get; set; }
        public int Id_tipo { get; set; }
    }
}
