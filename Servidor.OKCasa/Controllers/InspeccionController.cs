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
    [Route("api/Inspeccion")]
    public class InspeccionController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Inspeccion>());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Inspeccion>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Inspeccion inspeccion)
        {
            if (ConexionOracle.Insert(inspeccion))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //PUT
        [HttpPut("/{id}")]
        public IActionResult Put(int id, [FromBody]String Observaciones)
        {
            if (ConexionOracle.Update(new Inspeccion() { Id_inspeccion = id, Observaciones=Observaciones }))
            {
                return Ok(ConexionOracle.Get<Inspeccion>(id));
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
            if (ConexionOracle.Update(new Inspeccion() { Id_inspeccion = id }))
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