using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.Transbank.Models
{
    public class MedioPago
    {
        [Key]
        public int Id_medio { get; set; }
        public String Nombre { get; set; }
    }
}
