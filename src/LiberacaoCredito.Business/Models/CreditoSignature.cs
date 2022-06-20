using LiberacaoCredito.Business.Enums;
using LiberacaoCredito.Business.Interfaces;
using System;

namespace LiberacaoCredito.Business.Models
{
    public class CreditoSignature : ICreditoSignature
    {
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public TipoCredito TipoCredito { get; set; }
        public DateTime DataPrimeiroVencimento { get; set; }
         
    }
}
