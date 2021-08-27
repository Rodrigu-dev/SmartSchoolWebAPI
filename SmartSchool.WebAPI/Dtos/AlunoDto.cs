using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.Dtos
{
    public class AlunoDto
    {
        public int Id { get; set; }
        public int Matricula { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public int Idade { get; set; }
        public DateTime DataMatricula { get; set; } = DateTime.Now;
        public bool StatusMatricula { get; set; }
        
    }
}