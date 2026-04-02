using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using EleicaoBrasilApi.Models;
using Microsoft.AspNetCore.Mvc;
using EleicaoBrasilApi.Data;


namespace EleicaoBrasilApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidatosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CandidatosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]

        public IActionResult Getodos()
        {
            var candidatos = _context.Candidatos.ToList();
            return Ok(candidatos);
        }

        [HttpGet("Partido/{Partido}")]
        public IActionResult Get(string Partido)
        {
            var candidatos = _context.Candidatos.Where(c => c.Partido.Trim().ToLower() == Partido).ToList();
            if (!candidatos.Any())
            {
                return NotFound("Nenhum candidato nesse partido.");          
            }

            return Ok(candidatos);
        }

        [HttpPost]

        public IActionResult Post(Candidato candidato)
        {
            if(_context.Candidatos.Any(c => c.Numero == candidato.Numero))
            {
                return BadRequest("Já existe um candidato com esse número");
                
            }
             
            _context.Candidatos.Add(candidato);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { id = candidato.Id}, candidato);
        }

        [HttpPut("{id}")]

        public IActionResult Put(int id, Candidato candidato)
        {
            if (id != candidato.Id)
            {
                return BadRequest();
            }
            _context.Candidatos.Update(candidato);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        
        public IActionResult Delete(int id)
        {
            var candidato = _context.Candidatos.Find(id);
            if (candidato == null)
            {
                return NotFound();
            }

            _context.Candidatos.Remove(candidato);
            _context.SaveChanges();
            return NoContent();
        }



        
    }
}