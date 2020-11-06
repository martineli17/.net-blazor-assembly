using Crosscuting.Funcoes;
using System;

namespace Dominio.Entidades
{
    public abstract class Pessoa : Base
    {
        private string _cpf;
        public string Cpf { get => _cpf; set => _cpf = ValidadorCpf.ValidarCpf(value) ? value : null; }
        public DateTime DataNascimento { get; private set; }

        public int GetIdade() => (int)(DateTime.Now - DataNascimento).TotalDays / 365;

        public Pessoa(Guid id, string nome) : base(id, nome) { }

        public Pessoa() { }
    }
}
