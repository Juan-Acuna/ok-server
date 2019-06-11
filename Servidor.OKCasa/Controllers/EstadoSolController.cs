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
        [ProducesResponseType(typeof(List<EstadoSol>), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<EstadoSol>(DataBaseConUser.OkCasa);
            if (a != null && a.Count>0)
            {
                return Ok(a);
            }
            return BadRequest(new ResponseJson("No se encontraron registros."));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EstadoSol), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get(int id)
        {
            var a = con.Get<EstadoSol>(id, DataBaseConUser.OkCasa);
            if (a == null)
            {
                return BadRequest(new ResponseJson("No se encontro coincidencia."));
            }
            return Ok(a);
        }
        //POST
        [HttpPost]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Post([FromBody]EstadoSol estadoSol)
        {
            if (con.Insert(estadoSol, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro insertado."));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo insertar el registro."));
            }
        }
        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Delete(int id)
        {
            if (con.Delete(new EstadoSol() { Id_estado = id }, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro Eliminado."));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo eliminar el registro."));
            }
        }
    }
}