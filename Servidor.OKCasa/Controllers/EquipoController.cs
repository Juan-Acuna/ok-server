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
    [Route("api/Equipo")]
    public class EquipoController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Equipo>());
        }
        [HttpGet("/{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Equipo>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Equipo equipo)
        {
            if (ConexionOracle.Insert(equipo))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //PUT                    ************POR MODIFICAR
        [HttpPut("/{id}")]
        public IActionResult Put(int id, [FromBody]char disponible)
        {
            if (ConexionOracle.Update(new Equipo() { Id_equipo = id, Disponible=disponible}))
            {
                return Ok(ConexionOracle.Get<Equipo>(id));
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
            if (ConexionOracle.Update(new Equipo() { Id_equipo = id }))
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