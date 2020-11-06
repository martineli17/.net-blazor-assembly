using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Aluno : Pessoa
    {
        public Guid IdCurso { get; private set; }
        public Curso Curso { get; private set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; private set; }
        public Aluno(Guid id, string nome) : base(id, nome) { }
        public Aluno() { }
    }
}
