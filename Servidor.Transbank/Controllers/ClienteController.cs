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
    [Route("tbk/Cliente")]
    public class ClienteController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Cliente>(DataBaseConUser.Transbank));
        }
        [HttpGet("{rut}")]
        public IActionResult Get(String rut)
        {
            return Ok(con.Get<Cliente>(rut, DataBaseConUser.Transbank));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Cliente cliente)
        {
            if (con.Insert(cliente, DataBaseConUser.Transbank))
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        //PUT
        [HttpPut("{rut}")]
        public IActionResult Put(String rut, [FromBody]String nombre)
        {
            if (con.Update(new Cliente { Rut = rut, Nombre = nombre }, DataBaseConUser.Transbank))
            {
                return Ok(con.Get<Cliente>(rut, DataBaseConUser.Transbank));
            }
            else
            {
                return BadRequest();
            }
        }
        //DELETE
        [HttpDelete("{rut}")]
        public IActionResult Delete(String rut)
        {
            if (con.Delete(new Cliente { Rut = rut }, DataBaseConUser.Transbank))
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