using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>()
        {
            new Aluno(){
                Id = 1,
                Nome = "Marcos",
                SobreNome = "Almeida",
                Telefone = "123456"
            },
            new Aluno(){
                Id = 2,
                Nome = "Marta",
                SobreNome = "Kent",
                Telefone = "858522245"
            },
            new Aluno(){
                Id = 3,
                Nome = "Laura",
                SobreNome = "Maria",
                Telefone = "4561598"
            }
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }
        
        [HttpGet("byId/{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);   

        }

        [HttpGet("byNome")]
        public IActionResult GetByName(string nome, string SobreNome)
        {
            var aluno = Alunos.FirstOrDefault(a => 
            a.Nome.Contains(nome) && a.SobreNome.Contains(SobreNome)
            );
            if (aluno == null) return BadRequest("Aluno não encontrado");
            return Ok(aluno);   

        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);

        }
        
        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);

        }

        [HttpPatch("{id}")]
        public IActionResult Petch(int id, Aluno aluno)
        {
            return Ok(aluno);

        }

         [HttpDelete("{id}")]
        public IActionResult Put(int id)
        {
            return Ok();

        }

    }
}