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
    [Route("tbk/Banco")]
    public class BancoController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Banco>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Banco>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String nombre)
        {
            var banco = new Banco
            {
                Nombre = nombre
            };
            if (ConexionOracle.Insert(banco))
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
            if (ConexionOracle.Delete(new Banco { Id_banco = id }))
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
