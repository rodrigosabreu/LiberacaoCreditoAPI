using LiberacaoCredito.Business.Models;

namespace LiberacaoCredito.Business.Interfaces
{
    public interface ICreditoRepositorio
    {
        CreditoParam ObterParametrosCredito(ICreditoSignature CreditoSignature);
    }
}
