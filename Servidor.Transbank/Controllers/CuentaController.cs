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
        public IActionResult Post([FromBody]int fondos, [FromBody]String rut, [FromBody]int tipo, [FromBody]int banco)
        {
            var c = new Cuenta
            {
                Fondos = fondos,
                Rut = rut,
                Id_tipo = tipo,
                Id_banco = banco
            };
            if (con.Insert(c, DataBaseConUser.Transbank))
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
        public IActionResult Put(int id, [FromBody]int fondos)
        {
            if (con.Update(new Cuenta{ Id_cuenta = id, Fondos = fondos }, DataBaseConUser.Transbank))
            {
                return Ok(con.Get<Cuenta>(id), DataBaseConUser.Transbank);
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