using System;
using System.Collections.Generic;

namespace SmartSchool.WebAPI.V1.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime? DataFim { get; set; } = null;
        public bool Ativo { get; set; } = true;
        
        
    }
}