using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;

        public AlunoController(IRepository repo)
        {
            _repo = repo;
        }

        //api/aluno
        [HttpGet]
        public IActionResult Get()
        {
            var result = _repo.GetAllAlunos(true);
            return Ok(result);
        }
        
        //api/aluno/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);   

        }

        //api/aluno
        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            try
            {
                _repo.Add(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok(aluno);
                }

                return BadRequest("Aluno não cadastrado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar criar uma novo Aluno");
            }

        }
        
        //api/aluno
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Aluno aluno)
        {
           try
           {
               var verAluno = _repo.GetAlunoById(id);
                if (verAluno == null)
                {
                     return NotFound($"Aluno com id={id} não foi encontrada");
                }
                _repo.Update(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok(aluno);
                }
                return BadRequest("Aluno não Atualizado");
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
            var verAluno = _repo.GetAlunoById(id);
            if (verAluno == null)
            {
                return NotFound($"Aluno com id={id} não foi encontrada");
            }
            _repo.Update(aluno);
            if(_repo.SaveChanges())
            {
                return Ok(aluno);
            }
            return BadRequest("Aluno não Atualizado");
        }

        [HttpDelete("{id}")]
        public ActionResult<Aluno> Delete(int id)
        {
            try
            {
                var aluno = _repo.GetAlunoById(id);
                if (aluno == null)
                {
                    return NotFound($"Aluno com id={id} não foi encontrada");
                }
                _repo.Remove(aluno);
                if(_repo.SaveChanges())
                {
                    return Ok("Aluno deletado");
                }
                return BadRequest("Aluno não deletado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar excluir Aluno de id={id}");
            }
          
        }

    }
}