using System;

namespace Servidor.Transbank.Models
{
    public class Cuenta
    {
        public int Id_cuenta { get; set; }
        public String Rut { get; set; }
        public int Fondos { get; set; }
        public int Id_tipo { get; set; }
        public int Id_banco { get; set; }
    }
}
