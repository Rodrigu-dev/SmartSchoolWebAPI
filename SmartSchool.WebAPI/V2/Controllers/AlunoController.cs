using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Models;
using SmartSchool.WebAPI.V1.Dtos;

namespace SmartSchool.WebAPI.V2.Controllers
{
    /// <summary>
    /// Versão 2 do meu Controlador de Alunos
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="mapper"></param>
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método responsável por retornar todos os Alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

        /// <summary>
        /// Método responsável por retornar apenas um único Aluno por meio do Código ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);
            if (aluno == null) return BadRequest("Aluno não encontrado");
            
            var alunoDto = _mapper.Map<AlunoDto>(aluno);
            
            return Ok(alunoDto);   

        }

        //api/aluno
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto model)
        {
            try
            {
                var aluno = _mapper.Map<Aluno>(model);
                
                _repo.Add(aluno);
                if(_repo.SaveChanges())
                {
                    return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
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
        public IActionResult Put(int id, AlunoRegistrarDto model)
        {
           try
           {
               var aluno = _repo.GetAlunoById(id);
                if (aluno == null)
                {
                     return NotFound($"Aluno com id={id} não foi encontrada");
                }

                _mapper.Map(model, aluno);

                _repo.Update(aluno);
                
                if(_repo.SaveChanges())
                {
                     return Created($"/api/aluno/{model.Id}", _mapper.Map<AlunoDto>(aluno));
                }
                return BadRequest("Aluno não Atualizado");
           }
           catch (Exception)
           {
               
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o Aluno com id={id}");
           }

        }

       

        //api/aluno/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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