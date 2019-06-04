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
            return Ok(con.GetAll<Solicitud>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Solicitud>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String direccion, [FromBody]DateTime creacion,
            [FromBody]String rut,[FromBody]int servicio,[FromBody]int equipo)
        {
            Solicitud solicitud = new Solicitud
            {
                Direccion = direccion,
                Creacion = creacion,
                Usuario = rut,
                Id_servicio = servicio,
                Id_equipo = equipo,
                Id_estado = 1   //   --------------> SUPONIENDO QUE ESTADO 1 = EN ESPERA.
            };
            if (con.Insert(solicitud))
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
            if (con.Update(new Solicitud() { Id_solicitud=id, Id_estado=estado, Fin=fin }))
            {
                return Ok(con.Get<Solicitud>(id));
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
            if (con.Delete(new Solicitud() { Id_solicitud = id }))
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