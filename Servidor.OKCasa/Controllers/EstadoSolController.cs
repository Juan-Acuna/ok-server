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
    [Route("api/EstadoSol")]
    public class EstadoSolController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<EstadoSol>());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<EstadoSol>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]EstadoSol estadoSol)
        {
            if (ConexionOracle.Insert(estadoSol))
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
            if (ConexionOracle.Update(new EstadoSol() { Id_estado = id }))
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