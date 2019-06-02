using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.Banco.Models;

namespace Servidor.Banco.Controllers
{
    [Produces("application/json")]
    [Route("bancoestado/TipoCuenta")]
    public class TipoCuentaController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<TipoCuenta>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<TipoCuenta>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]int id, [FromBody]String nombre)
        {
            var tipo = new TipoCuenta
            { 
                Nombre = nombre
            };
            if (ConexionOracle.Insert(tipo))
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
            if (ConexionOracle.Delete(new TipoCuenta { Id_tipo = id }))
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