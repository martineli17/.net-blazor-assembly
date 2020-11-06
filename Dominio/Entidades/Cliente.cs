using System;

namespace Dominio.Entidades
{
    public class Cliente : Pessoa
    {
        public Conta Conta { get; set; }

        public Cliente(Guid id, string nome) : base(id, nome) { }
        public Cliente() { }
    }
}
