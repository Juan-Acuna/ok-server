﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Servidor.Datos;
using Servidor.Transbank.Models;

namespace Servidor.Transbank.Controllers
{
    [Produces("application/json")]
    [Route("tbk/Cliente")]
    public class ClienteController : Controller
    {
        //GET
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(ConexionOracle.GetAll<Cliente>());
        }
        [HttpGet("{rut}")]
        public IActionResult Get(String rut)
        {
            return Ok(ConexionOracle.Get<Cliente>(rut));
        }
        //POST
        [HttpPost]
        public IActionResult Post([FromBody]String rut, [FromBody]String nombre)
        {
            var cliente = new Cliente
            {
                Rut = rut,
                Nombre = nombre
            };
            if (ConexionOracle.Insert(cliente))
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
        public IActionResult Put(String rut, [FromBody]String nombre)
        {
            if (ConexionOracle.Update(new Cliente { Rut = rut, Nombre = nombre }))
            {
                return Ok(ConexionOracle.Get<Cliente>(rut));
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
            if (ConexionOracle.Delete(new Cliente { Rut = rut }))
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