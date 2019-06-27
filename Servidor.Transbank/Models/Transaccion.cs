using System;

namespace Servidor.Transbank.Models
{
    public class Transaccion
    {
        public int Id_transaccion { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_medio { get; set; }
        public int? Id_cuenta { get; set; }
        public int? Id_tarjeta { get; set; }
    }
}
