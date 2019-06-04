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
    [Route("ok-casa/EstadoSol")]
    public class EstadoSolController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<EstadoSol>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<EstadoSol>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String nombre)
        {
            var estadoSol = new EstadoSol
            {
                Nombre = nombre
            };
            if (con.Insert(estadoSol))
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
            if (con.Delete(new EstadoSol() { Id_estado = id }))
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