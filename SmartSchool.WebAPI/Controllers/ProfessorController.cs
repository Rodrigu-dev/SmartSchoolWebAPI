using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {

        private readonly IRepository _repo;

        public ProfessorController(IRepository repo)
        {
            _repo = repo;
        }

        //api/professsor
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllProfessores(true);
            return Ok(result);
        }

         //api/professor/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado");
            return Ok(professor);   

        }

        //api/professor
        [HttpPost]
        public IActionResult Post(Professor professor)
        {
             try
            {
                _repo.Add(professor);
                if(_repo.SaveChanges())
                {
                    return Ok(professor);
                }

                return BadRequest("Professor não cadastrado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar criar uma novo Professor");
            }
        }

        //api/professor
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Professor professor)
        {
           try
           {
               var verProf = _repo.GetProfessorById(id, false);
                if (verProf == null)
                {
                     return NotFound($"Professor com id={id} não foi encontrada");
                }
                 _repo.Update(professor);
                if(_repo.SaveChanges())
                {
                   return Ok(professor);
                }    
                return BadRequest("Professor não Atualizado");  
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
            var verProf = _repo.GetProfessorById(id, false);
            if (verProf == null)
            {
                return NotFound($"Professor com id={id} não foi encontrada");
            }
            _repo.Update(professor); 
            if (_repo.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não Atualizado");
        }

        [HttpDelete("{id}")]
        public ActionResult<Professor> Delete(int id)
        {
            try
            {
                var professor = _repo.GetProfessorById(id);
                if (professor == null)
                {
                    return NotFound($"Professor com id={id} não foi encontrada");
                }
                _repo.Remove(professor);
                if (_repo.SaveChanges())
                {
                    return Ok("Professor Deletado");
                }
                return BadRequest("Professor não deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                $"Erro ao tentar excluir Professor de id={id}");
            }
            
        }
      
    }
}