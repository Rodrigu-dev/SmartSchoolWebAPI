using System.Collections.Generic;

namespace SmartSchool.WebAPI.Models
{
    public class Curso
    {
        public Curso() { }
        public Curso(int id, string nomeCurso)
        {
            this.Id = id;
            this.NomeCurso = nomeCurso;

        }
        public int Id { get; set; }
        public string NomeCurso { get; set; }
        public IEnumerable<Disciplina> Disciplinas { get; set; }
    }
}