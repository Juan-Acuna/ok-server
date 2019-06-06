using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servidor.OKCasa.Models
{
    public class Equipo
    {
        [Key]
        public int Id_equipo { get; set; }
        public String Encargado { get; set; }
        public char Disponible { get; set; }
    }
}
