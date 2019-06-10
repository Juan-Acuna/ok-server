using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.Banco.Models;

namespace Servidor.Banco.Controllers
{
    [Produces("application/json")]
    [Route("bancoestado/Cuenta")]
    public class CuentaController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Cuenta>(DataBaseConUser.BancoEstado));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Cuenta>(id, DataBaseConUser.BancoEstado));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Cuenta cuenta)
        {
            if (con.Insert(cuenta, DataBaseConUser.BancoEstado))
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
        public IActionResult Put(int id, [FromBody]int fondos)
        {
            if (con.Update(new Cuenta{ Id_cuenta = id, Fondos = fondos }, DataBaseConUser.BancoEstado))
            {
                return Ok(con.Get<Cuenta>(id, DataBaseConUser.BancoEstado));
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
            if (con.Delete(new Cuenta{ Id_cuenta = id }, DataBaseConUser.BancoEstado))
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