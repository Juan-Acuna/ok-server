using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.OKCasa.Models;

namespace Servidor.OKCasa.Controllers
{
    [Produces("application/json")]
    [Route("api/Solicitud")]
    public class SolicitudController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Solicitud>());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Solicitud>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Solicitud solicitud)
        {
            if (ConexionOracle.Insert(solicitud))
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
        public IActionResult Put(int id, [FromBody]int estado, [FromBody]DateTime fin)
        {
            if (ConexionOracle.Update(new Solicitud() { Id_solicitud=id, Id_estado=estado, Fin=fin }))
            {
                return Ok(ConexionOracle.Get<Solicitud>(id));
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
            if (ConexionOracle.Update(new Solicitud() { Id_solicitud = id }))
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