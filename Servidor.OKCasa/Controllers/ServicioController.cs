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
        [ProducesResponseType(typeof(List<Servicio>), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<Servicio>(DataBaseConUser.OkCasa);
            if (a != null && a.Count > 0)
            {
                return Ok(a);
            }
            return BadRequest(new ResponseJson("No se encontraron registros."));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Servicio), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get(int id)
        {
            var a = con.Get<Servicio>(id, DataBaseConUser.OkCasa);
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
        public IActionResult Post([FromBody]Servicio servicio)
        {
            if (con.Insert(servicio, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro insertado.",true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo insertar el registro."));
            }
        }
        //PUT
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Servicio), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Put(int id, [FromBody]dynamic data)
        {
            var s = con.Get<Servicio>(id, DataBaseConUser.OkCasa);
            if(data.descripcion != null)
            {
                s.Descripcion = data.descripcion;
            }
            if (con.Update(s, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Servicio>(id, DataBaseConUser.OkCasa));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo modificar el registro"));
            }

        }
        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Delete(int id)
        {
            if (con.Delete(new Servicio() { Id_servicio = id }, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro Eliminado.",true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo eliminar el registro."));
            }
        }
    }
}