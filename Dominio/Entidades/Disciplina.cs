using Dominio.ValuesType;
using System;

namespace Dominio.Entidades
{
    public class Disciplina : Base
    {
        public double CargaHoraria { get; private set; }
        public double Nota { get; private set; }
        public double NotaMinimaAprovacao { get; private set; }
        public Curso Curso { get; private set; }
        public Disciplina(Guid id, string nome) : base(id, nome) {  }
        public Disciplina() {  }

        public EnumStatusFinal StatusFinalAprovacao(double nota) => nota >= NotaMinimaAprovacao ? EnumStatusFinal.Aprovado :
            nota >= 100 * 0.4 ? EnumStatusFinal.Recuperacao : EnumStatusFinal.Reprovado;

    }
}
