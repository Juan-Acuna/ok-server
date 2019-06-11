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
        //[Produces("application/json", Type = typeof(Equipo))]
        [ProducesResponseType(typeof(List<Equipo>), 200)]
        [ProducesResponseType(typeof(BadRequesJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<Equipo>(DataBaseConUser.OkCasa);
            if (a != null)
            {
                return Ok();
            }
            return BadRequest(new BadRequesJson("No hay equipos registrados"));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Equipo), 200)]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Equipo>(id, DataBaseConUser.OkCasa));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Equipo equipo)
        {
            if (con.Insert(equipo, DataBaseConUser.OkCasa))
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
            if (con.Update(new Equipo() { Id_equipo = id, Disponible=disponible}, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Equipo>(id, DataBaseConUser.OkCasa));
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
            if (con.Delete(new Equipo() { Id_equipo = id }, DataBaseConUser.OkCasa))
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