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
        //POST
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }
        //PUT
        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }
        //DELETE
        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}