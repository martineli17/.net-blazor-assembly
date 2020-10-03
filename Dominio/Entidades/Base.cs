using System;

namespace Dominio.Entidades
{
    public abstract class Base
    {
        public Guid Id { get; protected set; }
        public string Nome { get; protected set; }
        public Base(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Base()
        {
            Id = Guid.NewGuid();
        }


    }
}
