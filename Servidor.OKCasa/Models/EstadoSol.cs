using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Servidor.OKCasa.Models
{
    public class EstadoSol
    {
        [Key]
        public int Id_estado { get; set; }
        public String Nombre { get; set; }
    }
}
