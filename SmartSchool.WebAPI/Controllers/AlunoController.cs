using System;
using System.Collections.Generic;
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
    public class AlunoController : ControllerBase
    {
        private readonly SmartContext _context;

        public AlunoController(SmartContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult Get()
        {
            return Ok(_context.Alunos);
        }
        
        //api/byId/id
        [HttpGet("byId/{id}")]
        public ActionResult GetById(int id)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);   

        }

        [HttpGet("byName")]
        public ActionResult GetByName(string nome, string SobreNome)
        {
            var aluno = _context.Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.SobreNome.Contains(SobreNome)
            );
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);   

        }

        [HttpPost]
        public ActionResult Post(Aluno aluno)
        {
            try
            {
                _context.Add(aluno);        // Adiciona na Memória
                _context.SaveChanges();     // Inclui os dados no Banco de dados
                return Ok(aluno);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar criar uma novo Aluno");
                
            }
            

        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Aluno aluno)
        {
           try
           {
               var verAluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (verAluno == null)
                {
                     return BadRequest($"Aluno com id={id} não foi encontrada");
                }
                 _context.Update(aluno);    
                 _context.SaveChanges();     
                 return Ok(aluno);
           }
           catch (Exception)
           {
               
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o Aluno com id={id}");
           }

        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var verAluno = _context.Alunos.AsNoTracking().FirstOrDefault(a => a.Id == id);
                if (verAluno == null)
                {
                     return BadRequest($"Aluno com id={id} não foi encontrada");
                }
            _context.Update(aluno); 
            _context.SaveChanges();     
            return Ok(aluno);

        }

        [HttpDelete("{id}")]
        public ActionResult<Aluno> Delete(int id)
        {
            try
            {
                var aluno = _context.Alunos.FirstOrDefault(a => a.Id == id);
                if (aluno == null)
                {
                     return BadRequest($"Aluno com id={id} não foi encontrada");
                }
                _context.Remove(aluno);
                _context.SaveChanges();
                return aluno;
            }
            catch (Exception)
            {
                
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir Aluno de id={id}");
            }
            

        }

    }
}