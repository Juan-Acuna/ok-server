using System;
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
        public IActionResult Get()
        {
            return Ok(con.GetAll<Usuario>(DataBaseConUser.OkCasa));
        }
        [HttpGet("{rut}")]
        public IActionResult Get(String rut)
        {
            var a = con.Get<Usuario>(rut, DataBaseConUser.OkCasa);
            if (a == null)
            {
                return Json(new {Mensaje = "No existe un usuario con ese rut" });
            }
            return Ok(a);
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]Usuario usuario)
        {
            if (con.Insert(usuario, DataBaseConUser.OkCasa,false))
            {
                return Ok();
            }
            else{
                return BadRequest();
            }
        }
        //PUT
        [HttpPut("{rut}")]
        public IActionResult Put(String rut,[FromBody]dynamic data)
        {
            if (con.Update(new Usuario() { Rut = rut, Clave=data.clave,Email=data.email}, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Usuario>(rut, DataBaseConUser.OkCasa));
            }else
            {
                return BadRequest();
            }
            
        }
        //DELETE
        [HttpDelete("{rut}")]
        public IActionResult Delete(String rut)
        {
            if (con.Delete(new Usuario() { Rut = rut }, DataBaseConUser.OkCasa))
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