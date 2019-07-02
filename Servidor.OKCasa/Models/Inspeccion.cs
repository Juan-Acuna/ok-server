using System;

namespace Servidor.OKCasa.Models
{
    public class Inspeccion
    {
        public int Id_inspeccion { get; set; }
        public DateTime Fecha_visita { get; set; }
        public String Observaciones { get; set; }
        public int Monto { get; set; }
        public int Id_Solicitud { get; set; }
    }
}
