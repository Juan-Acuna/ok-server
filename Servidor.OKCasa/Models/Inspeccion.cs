using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor.Datos.Modelos.OKCasa
{
    class Inspeccion
    {
        public int Id_inspeccion { get; set; }
        public DateTime Fecha_visita { get; set; }
        public String Observaciones { get; set; }
        public int Monto { get; set; }
    }
}
