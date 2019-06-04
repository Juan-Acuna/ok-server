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
    [Route("ok-casa/Inspeccion")]
    public class InspeccionController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Inspeccion>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Inspeccion>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]DateTime fecha, [FromBody]String observaciones,
            [FromBody]int monto)
        {
            var inspeccion = new Inspeccion
            {
                Fecha_visita = fecha,
                Observaciones = observaciones,
                Monto = monto
            };
            if (con.Insert(inspeccion))
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
        public IActionResult Put(int id, [FromBody]String Observaciones)
        {
            if (con.Update(new Inspeccion() { Id_inspeccion = id, Observaciones=Observaciones }))
            {
                return Ok(con.Get<Inspeccion>(id));
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
            if (con.Delete(new Inspeccion() { Id_inspeccion = id }))
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