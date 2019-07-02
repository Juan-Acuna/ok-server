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
    [Route("tbk/Cuenta")]
    public class CuentaController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Cuenta>(DataBaseConUser.Transbank));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Cuenta>(id, DataBaseConUser.Transbank));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Cuenta cuenta)
        {
            if (con.Insert(cuenta, DataBaseConUser.Transbank))
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
        public IActionResult Put(int id, [FromBody]dynamic data)
        {
            var c = con.Get<Cuenta>(id, DataBaseConUser.Transbank);
            if(data.fondos != null)
            {
                c.Fondos = data.fondos;
            }
            if (con.Update(c, DataBaseConUser.Transbank))
            {
                return Ok(con.Get<Cuenta>(id, DataBaseConUser.Transbank));
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
            if (con.Delete(new Cuenta { Id_cuenta = id }, DataBaseConUser.Transbank))
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