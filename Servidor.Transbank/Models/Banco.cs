using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.Transbank.Models
{
    public class Banco
    {
        [Key]
        public int Id_banco { get; set; }
        public String Nombre { get; set; }
    }
}
