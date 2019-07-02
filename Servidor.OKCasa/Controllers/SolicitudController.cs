using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.OKCasa.Models;

namespace Servidor.OKCasa.Controllers
{
    [Produces("application/json")]
    [Route("ok-casa/Solicitud")]
    public class SolicitudController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        [ProducesResponseType(typeof(List<Solicitud>), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<Solicitud>(DataBaseConUser.OkCasa);
            if (a != null)
            {
                return Ok(a);
            }
            return BadRequest(new ResponseJson("No se encontraron registros."));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Solicitud), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get(int id)
        {
            var a = con.Get<Solicitud>(id, DataBaseConUser.OkCasa);
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
        public IActionResult Post([FromBody]Solicitud solicitud)
        {
            if (con.Insert(solicitud, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro insertado.", true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo insertar el registro."));
            }
        }
        //PUT
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Solicitud), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Put(int id, [FromBody]dynamic data)
        {
            var s = con.Get<Solicitud>(id, DataBaseConUser.OkCasa);
            if (data.estado != null)
            {
                s.Id_estado = data.estado;
                if (data.estado == 3)
                {
                    s.Fin = DateTime.Now;
                }
            }
            if (con.Update(s, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Solicitud>(id, DataBaseConUser.OkCasa));
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
            if (con.Delete(new Solicitud() { Id_solicitud = id }, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro Eliminado.", true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo eliminar el registro."));
            }
        }
    }
}