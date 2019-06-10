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
        public IActionResult Get()
        {
            return Ok(con.GetAll<Solicitud>(DataBaseConUser.OkCasa));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Solicitud>(id, DataBaseConUser.OkCasa));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Solicitud solicitud)
        {
            if (con.Insert(solicitud, DataBaseConUser.OkCasa))
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
        public IActionResult Put(int id, [FromBody]int estado, [FromBody]DateTime fin)
        {
            if (con.Update(new Solicitud() { Id_solicitud=id, Id_estado=estado, Fin=fin }, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Solicitud>(id, DataBaseConUser.OkCasa));
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
            if (con.Delete(new Solicitud() { Id_solicitud = id }, DataBaseConUser.OkCasa))
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