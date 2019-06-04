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
    [Route("ok-casa/TipoUsuario")]
    public class TipoUsuarioController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<TipoUsuario>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<TipoUsuario>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String nombre)
        {
            TipoUsuario tipoUsuario = new TipoUsuario
            {
                Nombre = nombre
            };
            if (con.Insert(tipoUsuario))
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
            if (con.Delete(new TipoUsuario() { Id_tipo = id }))
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