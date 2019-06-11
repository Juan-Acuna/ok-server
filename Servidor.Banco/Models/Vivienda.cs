using System;

namespace Servidor.Banco.Models
{
    public class Vivienda
    {
        public int Id_vivienda { get; set; }
        public String Direccion { get; set; }
        public String Rut { get; set; }
        public int Id_tipo { get; set; }
    }
}
