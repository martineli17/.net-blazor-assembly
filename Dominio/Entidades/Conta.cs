using System;

namespace Dominio.Entidades
{
    public class Conta : Base
    {
        public Guid IdCliente { get; private set; }
        public string NumeroConta { get; private set; }
        public decimal Saldo { get; private set; }
        public Cliente Cliente { get; private set; }

        public bool Sacar(decimal valor)
        {
            var valido = Saldo >= valor;
            Console.WriteLine("SALDO ENTIDADE: " + Saldo);
            Console.WriteLine(valido);
            if (valido) Saldo -= valor;
            return valido;
        }

        public void Depositar(decimal valor) => Saldo += valor;

        public Conta(Guid id, string nome) : base(id, nome) { }
        public Conta() { }
    }
}
