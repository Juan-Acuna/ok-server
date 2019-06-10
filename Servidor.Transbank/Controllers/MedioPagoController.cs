using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.Transbank.Models;

namespace Servidor.Transbank.Controllers
{
    [Produces("application/json")]
    [Route("tbk/MedioPago")]
    public class MedioPagoController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<MedioPago>(DataBaseConUser.Transbank));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<MedioPago>(id, DataBaseConUser.Transbank));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]MedioPago medio)
        {
            if (con.Insert(medio, DataBaseConUser.Transbank))
            {
                return Ok();
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
            if (con.Delete(new MedioPago { Id_medio = id }, DataBaseConUser.Transbank))
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