using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor.Datos.Modelos.OKCasa
{
    class Usuario
    {
        public String Rut { get; set; }
        public String Nombre { get; set; }
        public String Clave { get; set; }
        public String Email { get; set; }
        public DateTime Fecha_nac { get; set; }
        public int Id_tipo { get; set; }
    }
}
