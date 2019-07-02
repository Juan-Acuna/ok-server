using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.OKCasa.Models;

namespace Servidor.OKCasa.Controllers
{
    [Produces("application/json")]
    [Route("ok-casa/Inspeccion")]
    public class InspeccionController : Controller
    {
        ConexionOracle con = ConexionOracle.Conexion;
        //GET
        [HttpGet]
        [ProducesResponseType(typeof(List<Inspeccion>), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get()
        {
            var a = con.GetAll<Inspeccion>(DataBaseConUser.OkCasa);
            if (a != null)
            {
                return Ok(a);
            }
            return BadRequest(new ResponseJson("No se encontraron registros."));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Inspeccion), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Get(int id)
        {
            var a = con.Get<Inspeccion>(id, DataBaseConUser.OkCasa);
            if (a == null)
            {
                return BadRequest(new ResponseJson("No se encontro coincidencia."));
            }
            return Ok(a);
        }
        //POST
        [HttpPost]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Post([FromBody]Inspeccion inspeccion)
        {
            var rs = con.Insert(inspeccion, DataBaseConUser.OkCasa);
            if (rs)
            {
                return Ok(new ResponseJson("Registro insertado.",true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo insertar el registro."));
            }
        }
        //PUT
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Inspeccion), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Put(int id, [FromBody]dynamic data)
        {
            var i = con.Get<Inspeccion>(id, DataBaseConUser.OkCasa);
            if(data.observaciones != null)
            {
                i.Observaciones = data.observaciones;
            }
            if (con.Update(i, DataBaseConUser.OkCasa))
            {
                return Ok(con.Get<Inspeccion>(id, DataBaseConUser.OkCasa));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo modificar el registro"));
            }

        }
        //DELETE
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ResponseJson), 200)]
        [ProducesResponseType(typeof(ResponseJson), 400)]
        public IActionResult Delete(int id)
        {
            if (con.Delete(new Inspeccion() { Id_inspeccion = id },DataBaseConUser.OkCasa))
            {
                return Ok(new ResponseJson("Registro Eliminado.",true));
            }
            else
            {
                return BadRequest(new ResponseJson("No se pudo eliminar el registro."));
            }
        }
    }
}