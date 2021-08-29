using System;
using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.WebAPI.Data;
using SmartSchool.WebAPI.Dtos;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        //api/professsor
        [HttpGet]
        public IActionResult Get()
        {
            var professor = _repo.GetAllProfessores(true);
            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professor));
        }

         //api/professor/
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null) return BadRequest("Professor não encontrado");
            
            var professorDto = _mapper.Map<ProfessorDto>(professor);
            return Ok(professorDto);   

        }

        //api/professor
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto model)
        {
             try
            {
                var professor = _mapper.Map<Professor>(model);

                _repo.Add(professor);
                if(_repo.SaveChanges())
                {
                    return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
                }

                return BadRequest("Professor não cadastrado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Erro ao tentar criar uma novo Professor");
            }
        }

        //api/professor/
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto model)
        {
           try
           {
               var professor = _repo.GetProfessorById(id, false);
                if (professor == null)
                {
                     return NotFound($"Professor com id={id} não foi encontrada");
                }

                _mapper.Map(model, professor);

                _repo.Update(professor);
                
                if(_repo.SaveChanges())
                {
                   return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
                }    
                return BadRequest("Professor não Atualizado");  
           }
           catch (Exception)
           {
                return StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar o Professor com id={id}");
           }

        }

        //api/professor/
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto model)
        {
            var professor = _repo.GetProfessorById(id, false);
            if (professor == null)
            {
                return NotFound($"Professor com id={id} não foi encontrada");
            }

            _mapper.Map(model, professor);

            _repo.Update(professor); 
            if (_repo.SaveChanges())
            {
                return Created($"/api/professor/{model.Id}", _mapper.Map<ProfessorDto>(professor));
            }
            return BadRequest("Professor não Atualizado");
        }

        //api/professor/
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
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