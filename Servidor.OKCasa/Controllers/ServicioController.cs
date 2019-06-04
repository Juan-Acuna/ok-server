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
    [Route("ok-casa/Servicio")]
    public class ServicioController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Servicio>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Servicio>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String nombre, [FromBody]String descripcion,
            [FromBody]int costo)
        {
            Servicio servicio = new Servicio
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Costo = costo
            };
            if (con.Insert(servicio))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //PUT
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]String descripcion, [FromBody]int costo)
        {
            if (con.Update(new Servicio() { Id_servicio = id, Descripcion = descripcion, Costo = costo }))
            {
                return Ok(con.Get<Servicio>(id));
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
            if (con.Delete(new Servicio() { Id_servicio = id }))
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