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
    [Route("bancoestado/Cliente")]
    public class ClienteController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Cliente>(DataBaseConUser.BancoEstado));
        }
        [HttpGet("{rut}")]
        public IActionResult Get(String rut)
        {
            return Ok(con.Get<Cliente>(rut, DataBaseConUser.BancoEstado));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Cliente cliente)
        {
            if (con.Insert(cliente, DataBaseConUser.BancoEstado,false))
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
        public IActionResult Put(String rut, [FromBody]dynamic data)
        {
            var c = con.Get<Cliente>(rut, DataBaseConUser.BancoEstado);
            if(data.nombre != null)
            {
                c.Nombre = data.nombre;
            }
            if (con.Update(c, DataBaseConUser.BancoEstado))
            {
                return Ok(con.Get<Cliente>(rut, DataBaseConUser.BancoEstado));
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
            if (con.Delete(new Cliente{ Rut = rut }, DataBaseConUser.BancoEstado))
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