using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.OKCasa.Models
{
    public class Servicio
    {
        public int Id_servicio { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int Costo { get; set; }
    }
}
