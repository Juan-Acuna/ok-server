using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.Transbank.Models
{
    public class Transaccion
    {
        [Key]
        public int Id_transaccion { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public int Id_medio { get; set; }
        public String Rut { get; set; }
    }
}
