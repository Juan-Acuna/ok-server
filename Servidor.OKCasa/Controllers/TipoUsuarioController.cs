using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.OKCasa.Models;

namespace Servidor.OKCasa.Controllers
{
    [Produces("application/json")]
    [Route("api/TipoUsuario")]
    public class TipoUsuarioController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<TipoUsuario>());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<TipoUsuario>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]TipoUsuario tipoUsuario)
        {
            if (ConexionOracle.Insert(tipoUsuario))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //DELETE
        [HttpDelete("/{id}")]
        public IActionResult Delete(int id)
        {
            if (ConexionOracle.Update(new TipoUsuario() { Id_tipo = id }))
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