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
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Cuenta>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(ConexionOracle.Get<Cuenta>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]int id, [FromBody]String clave,
            [FromBody]int fondos, [FromBody]String rut, [FromBody]int tipo)
        {
            var cuenta = new Cuenta
            {
                Clave = clave,
                Fondos = fondos,
                Rut = rut,
                Id_tipo = tipo
            };
            if (ConexionOracle.Insert(cuenta))
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
            if (ConexionOracle.Update(new Cuenta{ Id_cuenta = id, Fondos = fondos }))
            {
                return Ok(ConexionOracle.Get<Cuenta>(id));
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
            if (ConexionOracle.Delete(new Cuenta{ Id_cuenta = id }))
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