using Microsoft.AspNetCore.Mvc;
using ImobliariaAPI.Models.Apartamento;
using System.Collections.Generic;
using System.IO;
using System;

namespace ImobliariaAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartamentosController : ControllerBase
    {
        public static List<Apartamento> apartamentos = new List<Apartamento>();

        [HttpGet]
        public ActionResult<List<Apartamento>> Get()
        {   
            return Ok(apartamentos);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<List<Apartamento>> Get(int id)
        {
            var apartamento = apartamentos.Find(apt => apt.Id.Equals(id));
            
            if(apartamento == null)
            {
                return NotFound();
            }else
            {
                return Ok(apartamento);
            }
        }

        [HttpPost]
        public ActionResult Post(Apartamento apt)
        {
            apartamentos.Add(apt);
            var resourceUrl = Path.Combine(Request.Path.ToString(), Uri.EscapeUriString(apt.Id.ToString()));

            return Created(resourceUrl,apt);
        }


        [HttpPut]
        public ActionResult Put(Apartamento apt){

            var apartamento = apartamentos.Find(item => item.Id.Equals(apt.Id));
            Console.WriteLine("Put");

            if(apartamento == null)
            {
                return BadRequest("Apartamento não encontrado");
            }else
            {
                apartamentos.ForEach(item => {
                    if(item.Id == apt.Id)
                    {
                        item = apt;
                    }
                });
                return Ok();
            }
        }

    }
}