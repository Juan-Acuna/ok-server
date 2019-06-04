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
    [Route("bancoestado/Vivienda")]
    public class ViviendaController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(con.GetAll<Vivienda>());
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(con.Get<Vivienda>(id));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]int id, [FromBody]String direccion,
            [FromBody]String rut, [FromBody]int tipo)
        {
            var vivienda = new Vivienda
            {
                Direccion = direccion,
                Rut = rut,
                Id_tipo = tipo
            };
            if (con.Insert(vivienda))
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
        public IActionResult Put(int id, [FromBody]String rut)
        {
            if (con.Update(new Vivienda{ Id_vivienda = id, Rut = rut }))
            {
                return Ok(con.Get<Vivienda>(id));
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
            if (con.Delete(new Vivienda{ Id_vivienda = id }))
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