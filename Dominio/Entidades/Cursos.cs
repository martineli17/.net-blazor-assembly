using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Curso : Base
    {
        public List<Aluno> QtAluno { get; private set; }
        public List<Disciplina> DiciplinaCurso { get; private set; }
        public string Turno { get; private set;  }
        public Curso(Guid id, string nome) : base(id, nome) { }   
        public Curso()
        {

        }
    }
}
