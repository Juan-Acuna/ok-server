using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.Transbank.Models;

namespace Servidor.Transbank.Controllers
{
    [Produces("application/json")]
    [Route("tbk/Transaccion")]
    public class TransaccionController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Transaccion>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Transaccion>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]int monto, [FromBody]DateTime fecha, [FromBody]String rut, [FromBody]int medio)
        {
            var t = new Transaccion
            {
                Monto = monto,
                Fecha = fecha,
                Id_medio = medio,
                Rut = rut
            };
            if (ConexionOracle.Insert(t))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (ConexionOracle.Delete(new Transaccion { Id_transaccion = id }))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}