using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.OKCasa.Models;

namespace Servidor.OKCasa.Controllers
{
    [Produces("application/json")]
    [Route("ok-casa/Usuario")]
    public class UsuarioController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        [ProducesResponseType(typeof(List<Usuario>), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<Usuario>(DataBaseConUser.OkCasa);
            if (a != null)
            {
                return Ok(a);
            }
            return BadRequest(new ResponseJson("No se encontraron registros."));
        }
        [HttpGet("{rut}")]
        [ProducesResponseType(typeof(Usuario), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get(String rut)
        {
            var a = con.Get<Usuario>(rut, DataBaseConUser.OkCasa);
            if (a == null)
            {
                return Json(new ResponseJson("No existe un usuario con ese rut"));
            }
            return Ok(a);
        }
        //POST
        [HttpPost]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            if (con.Insert(usuario, DataBaseConUser.OkCasa,false))
            {
                return Ok(new ResponseJson("Registro insertado.", true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo insertar el registro."));
            }
        }
        //PUT
        [HttpPut("{rut}")]
        [ProducesResponseType(typeof(Servicio), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Put(String rut,[FromBody]dynamic data)
        {
            if (con.Update(new Usuario() { Rut = rut, Clave = data.clave, Email = data.email }, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Usuario>(rut, DataBaseConUser.OkCasa));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo modificar el registro"));
            }
        }
        //DELETE
        [HttpDelete("{rut}")]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Delete(String rut)
        {
            if (con.Delete(new Usuario() { Rut = rut }, DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro Eliminado.", true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo eliminar el registro."));
            }
        }
    }
}