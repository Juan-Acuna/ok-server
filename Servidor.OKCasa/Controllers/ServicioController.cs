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
    [Route("api/Servicio")]
    public class ServicioController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Servicio>());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Servicio>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Servicio servicio)
        {
            if (ConexionOracle.Insert(servicio))
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
        public IActionResult Put(int id, [FromBody]String descripcion, [FromBody]int costo)
        {
            if (ConexionOracle.Update(new Servicio() { Id_servicio = id, Descripcion = descripcion, Costo = costo }))
            {
                return Ok(ConexionOracle.Get<Servicio>(id));
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
            if (ConexionOracle.Update(new Servicio() { Id_servicio = id }))
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