using System;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SmartContext _context;
        public ProfessorController(SmartContext context) { 
            _context = context;
        }
         //api/professsor
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.Professores);
        }

         //api/professor/byId/id
        [HttpGet("byId/{id}")]
        public ActionResult GetById(int id)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);   

        }

        //api/professor/byName?nome=nome
        [HttpGet("byName")]
        public ActionResult GetByName(string name)
        {
            var professor = _context.Professores.FirstOrDefault(a => a.Nome.Contains(name));
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);   

        }

        //api/professor
        [HttpPost]
        public ActionResult Post(Professor professor)
        {
            try
            {
                _context.Add(professor);        // Adiciona na Memória
                _context.SaveChanges();     // Inclui os dados no Banco de dados
                return Ok(professor);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar criar uma novo Professor");
            }
        }

        //api/professor
        [HttpPut("{id}")]
        public ActionResult Put(int id, Professor professor)
        {
           try
           {
               var verProf = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (verProf == null)
                {
                     return BadRequest($"Professor com id={id} não foi encontrada");
                }
                 _context.Update(professor);    
                 _context.SaveChanges();     
                 return Ok(professor);
           }
           catch (Exception)
           {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o Professor com id={id}");
           }

        }

         [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var verProf = _context.Professores.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (verProf == null)
                {
                     return BadRequest($"Professor com id={id} não foi encontrada");
                }
            _context.Update(professor); 
            _context.SaveChanges();     
            return Ok(professor);

        }

        [HttpDelete("{id}")]
        public ActionResult<Professor> Delete(int id)
        {
            try
            {
                var professor = _context.Professores.FirstOrDefault(a => a.Id == id);
                if (professor == null)
                {
                     return BadRequest($"Professor com id={id} não foi encontrada");
                }
                _context.Remove(professor);
                _context.SaveChanges();
                return professor;
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar excluir Professor de id={id}");
            }
            

        }



       
    }
}