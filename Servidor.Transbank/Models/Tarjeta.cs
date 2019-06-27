using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.Transbank.Models
{
    public class Tarjeta
    {
        public int Id_tarjeta { get; set; }
        public int Numero { get; set; }
        public int Cvv { get; set; }
        public String exp { get; set; }
        public int Id_financiera { get; set; }
    }
}
