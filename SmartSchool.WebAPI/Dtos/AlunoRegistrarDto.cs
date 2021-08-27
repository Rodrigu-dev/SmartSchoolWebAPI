using System;
using System.Collections.Generic;
using SmartSchool.WebAPI.Models;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoRegistrarDto
    {
        
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; } 
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool StatusMatricula { get; set; } = true;
        
    }
}