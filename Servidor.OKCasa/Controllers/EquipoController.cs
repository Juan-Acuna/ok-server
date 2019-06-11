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
        [ProducesResponseType(typeof(List<Equipo>), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<Equipo>(DataBaseConUser.OkCasa);
            if (a != null)
            {
                return Ok();
            }
            return BadRequest(new ResponseJson("No se encontraron registros."));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Equipo), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get(int id)
        {
            var a = con.Get<Equipo>(id, DataBaseConUser.OkCasa);
            if (a != null)
            {
                return Ok(a);
            }
            return BadRequest(new ResponseJson("No se encontro el registro."));
        }
        //POST
        [HttpPost]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Post([FromBody]Equipo equipo)
        {
            if (con.Insert(equipo, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro insertado."));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo insertar el registro"));
            }
        }
        //PUT
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Equipo), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Put(int id, [FromBody]char disponible)
        {
            if (con.Update(new Equipo() { Id_equipo = id, Disponible=disponible}, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Equipo>(id, DataBaseConUser.OkCasa));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo actualizar el registro"));
            }

        }
        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Delete(int id)
        {
            if (con.Delete(new Equipo() { Id_equipo = id }, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro eliminado."));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo eliminar el registro."));
            }
        }
    }
}