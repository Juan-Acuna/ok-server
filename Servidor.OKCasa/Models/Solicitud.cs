using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor.Datos.Modelos.OKCasa
{
    class Solicitud
    {
        public int Id_solicitud { get; set; }
        public String Direccion { get; set; }
        public DateTime Creacion { get; set; }
        public DateTime Fin { get; set; }
        public String Usuario { get; set; }
        public int Id_estado { get; set; }
        public int Id_servicio { get; set; }
        public int Id_equipo { get; set; }
        public int Id_inspeccion { get; set; }
    }
}
