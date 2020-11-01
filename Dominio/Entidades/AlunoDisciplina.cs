using System;

namespace Dominio.Entidades
{
    public class AlunoDisciplina : Base
    {
        public Guid IdAluno { get; private set; }
        public Guid IdDisciplina { get; private set; }
        public double? Nota { get; private set; }
        public Disciplina Disciplina { get; private set; }
        public Aluno Aluno { get; private set; }

        public AlunoDisciplina()
        {

        }
    }
}
