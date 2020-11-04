using Dominio.ValuesType;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Dominio.Entidades
{
    public class Disciplina : Base
    {
        public Guid IdCurso { get; private set; }
        public double CargaHoraria { get; private set; }
        public double NotaMinimaAprovacao { get; private set; }
        public Curso Curso { get; private set; }
        public IEnumerable<AlunoDisciplina> AlunoDisciplina { get; private set; }
        public Disciplina(Guid id, string nome) : base(id, nome) {  }
        public Disciplina() {  }

        public EnumStatusFinal StatusFinalAprovacao(double nota) => nota >= NotaMinimaAprovacao ? EnumStatusFinal.Aprovado :
            nota >= NotaMaxima(NotaMinimaAprovacao) * 0.4 ? EnumStatusFinal.Recuperacao : EnumStatusFinal.Reprovado;

        private double NotaMaxima(double NotaMinima)
        {
            double NotaMaxima;
            double completaNota;
            NotaMinima = NotaMinimaAprovacao;

            completaNota = NotaMinima * 40 / NotaMinima;
            NotaMaxima = completaNota + NotaMinima;

            return NotaMaxima;
        }

    }
}
