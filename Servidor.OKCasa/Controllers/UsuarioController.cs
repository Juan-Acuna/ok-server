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
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Usuario>());
        }
        [HttpGet("{rut}")]
        public IActionResult Get(String rut)
        {
            return Ok(ConexionOracle.Get<Usuario>(rut));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String rut, [FromBody]String nombre,
            [FromBody]String clave, [FromBody]String email,DateTime nacimiento,
            [FromBody]int tipo)
        {
            Usuario usuario = new Usuario
            {
                Rut = rut,
                Nombre = nombre,
                Clave = clave,
                Email = email,
                Fecha_nac = nacimiento,
                Id_tipo = tipo
            };
            if (ConexionOracle.Insert(usuario))
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
            if (ConexionOracle.Update(new Usuario() { Rut = rut, Clave=clave,Email=email}))
            {
                return Ok(ConexionOracle.Get<Usuario>(rut));
            }else
            {
                return BadRequest();
            }
            
        }
        //DELETE
        [HttpDelete("{rut}")]
        public IActionResult Delete(String rut)
        {
            if (ConexionOracle.Delete(new Usuario() { Rut = rut }))
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