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
    [Route("bacoestado/TipoVivienda")]
    public class TipoViviendaController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<TipoVivienda>(DataBaseConUser.BancoEstado));
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<TipoVivienda>(id, DataBaseConUser.BancoEstado));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]int id, [FromBody]String nombre)
        {
            var tipo = new TipoVivienda
            {
                Nombre = nombre
            };
            if (con.Insert(tipo, DataBaseConUser.BancoEstado))
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
            if (con.Delete(new TipoVivienda { Id_tipo = id }, DataBaseConUser.BancoEstado))
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