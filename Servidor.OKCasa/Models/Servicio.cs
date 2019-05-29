using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor.Datos.Modelos.OKCasa
{
    class Servicio
    {
        public int Id_servicio { get; set; }
        public String Nombre { get; set; }
        public String Descripcion { get; set; }
        public int Costo { get; set; }
    }
}
