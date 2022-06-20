using LiberacaoCredito.Business.Models;

namespace LiberacaoCredito.Business.Interfaces
{
    public interface ICreditoService
    {
        ResponseBase Simular(ICreditoSignature creditoSignature);
        public bool Validar(ICreditoSignature creditoSignature, CreditoParam creditoParam);
    }
}
