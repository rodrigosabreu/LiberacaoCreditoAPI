using LiberacaoCredito.Business.Enums;
using System;

namespace LiberacaoCredito.Business.Interfaces
{
    public interface ICreditoSignature
    {        
        decimal ValorCredito { get; set; }
        int QuantidadeParcelas { get; set; }
        TipoCredito TipoCredito { get; set; }
        DateTime DataPrimeiroVencimento { get; set; }             

    }
}