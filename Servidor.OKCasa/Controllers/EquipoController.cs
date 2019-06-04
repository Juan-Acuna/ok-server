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
    [Route("ok-casa/Equipo")]
    public class EquipoController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Equipo>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Equipo>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String encargado, [FromBody]Char disponible)
        {
            var equipo = new Equipo
            {
                Encargado = encargado,
                Disponible = disponible,
            };
            if (con.Insert(equipo))
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
        public IActionResult Put(int id, [FromBody]char disponible)
        {
            if (con.Update(new Equipo() { Id_equipo = id, Disponible=disponible}))
            {
                return Ok(con.Get<Equipo>(id));
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
            if (con.Delete(new Equipo() { Id_equipo = id }))
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