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
        public IActionResult Post([FromBody]Usuario data)
        {
            Usuario usuario = new Usuario
            {
                Rut = data.Rut,
                Nombre = data.Nombre,
                Clave = data.Clave,
                Email = data.Email,
                Fecha_nac = data.Fecha_nac,
                Id_tipo = data.Id_tipo
            };
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
        public IActionResult Put(String rut,[FromBody]String clave,[FromBody]String email)
        {
            if (con.Update(new Usuario() { Rut = rut, Clave=clave,Email=email}, DataBaseConUser.OkCasa))
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