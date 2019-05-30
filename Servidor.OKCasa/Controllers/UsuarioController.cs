using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Servidor.OKCasa.Controllers
{
    [Produces("application/json")]
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
        [HttpGet("/{rut}")]
        public IActionResult Get(String rut)
        {
            return Ok();
        }
        //POST
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        //PUT
        [HttpPut("/{rut}")]
        public IActionResult Put(String rut)
        {
            return Ok();
        }
        //DELETE
        [HttpDelete("/{rut}")]
        public IActionResult Delete(String rut)
        {
            return Ok();
        }
    }
}