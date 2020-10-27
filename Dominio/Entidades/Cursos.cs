using Dominio.ValuesType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Curso : Base
    {
        public Guid IdAluno { get; private set; }
        public Guid IdDisciplina { get; private set; }
        public List<Aluno> Alunos { get; private set; }
        public List<Disciplina> Diciplinas { get; private set; }
        public double CargaHoraria { get; private set;  }
        public string AreaAtuacao { get; private set;  }
        public EnumTurno Turno { get; private set;  }
        public Curso(Guid id, string nome) : base(id, nome) { }   
        public Curso()
        {

        }
    }
}
