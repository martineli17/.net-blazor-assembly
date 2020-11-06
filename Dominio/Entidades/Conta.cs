using System;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public Guid IdCliente { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal Saldo { get; private set; }
        public Cliente Cliente { get; private set; }

        public void Sacar(decimal valor)
        {
            if (Saldo >= valor)
                Saldo -= valor;
        }

        public void Depositar(decimal valor) => Saldo += valor;

        public Conta(Guid id, string nome) : base(id, nome) { }
        public Conta() { }
    }
}
