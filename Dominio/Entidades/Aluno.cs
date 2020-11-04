using Crosscuting.Funcoes;
using System;
using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Aluno : Base
    {
        private string _cpf;
        public Guid IdCurso { get; private set; }
        public string Cpf { get => _cpf; set => _cpf = ValidadorCpf.ValidarCpf(value) ? value : null; }
        public DateTime DataNascimento { get; private set; }
        public Curso Curso { get; private set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; private set; }
        public Aluno(Guid id, string nome) : base(id, nome) { }
        public Aluno()
        {
        }

        public int GetIdade() => (int)(DateTime.Now - DataNascimento).TotalDays / 365;
    }
}
