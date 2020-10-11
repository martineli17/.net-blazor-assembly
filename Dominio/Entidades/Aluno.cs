using System;

namespace Dominio.Entidades
{
    public class Aluno : Base
    {
        public Guid IdCurso { get; private set; }
        public string Cpf { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public Curso Curso { get; private set; }
        public Aluno(Guid id, string nome) : base(id, nome) { }
        public Aluno()
        {
        }

        public int GetIdade() => (int)(DateTime.Now - DataNascimento).TotalDays / 365;
    }
}
