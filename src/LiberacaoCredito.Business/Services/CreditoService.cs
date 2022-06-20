using LiberacaoCredito.Business.Interfaces;
using LiberacaoCredito.Business.Models;
using System;

namespace LiberacaoCredito.Business.Services
{
    public class CreditoService : ICreditoService 
    {
        private ICreditoRepositorio _creditoRepositorio;

        public CreditoService(ICreditoRepositorio creditoRepositorio)
        {
            _creditoRepositorio = creditoRepositorio;
        }

        public ResponseBase Simular(ICreditoSignature creditoSignature)
        {
            try
            {
                var param = _creditoRepositorio.ObterParametrosCredito(creditoSignature);

                var juros = CalcularTaxaJurosSimples(creditoSignature, param);
                var total = CalcularValorTotal(juros, creditoSignature.ValorCredito);

                if (!Validar(creditoSignature, param))
                {
                    return new ResponseBase
                    {
                        HttpStatus = System.Net.HttpStatusCode.OK,
                        Response = null,
                        Mensagem = "Crédito Recusado"
                    };
                }
                               

                return new ResponseBase
                {
                    HttpStatus = System.Net.HttpStatusCode.Created,
                    Response = new { ValorTotal = total, ValorJuros = juros },
                    Mensagem = "Crédito Aprovado"
                };
            }
            catch (Exception)
            {
                return new ResponseBase
                {
                    HttpStatus = System.Net.HttpStatusCode.InternalServerError,
                    Response = null,
                    Mensagem = "Erro interno na API"
                };
            }
        }

        public bool Validar(ICreditoSignature creditoSignature, CreditoParam creditoParam)
        {
            if (!(creditoSignature.ValorCredito > creditoParam.VALOR_EMPRESTIMO_MIN) || !(creditoSignature.ValorCredito <= creditoParam.VALOR_EMPRESTIMO_MAX))
                return false;

            if (!(creditoSignature.QuantidadeParcelas > creditoParam.QTD_PARCELAS_MIN) || !(creditoSignature.QuantidadeParcelas <= creditoParam.QTD_PARCELAS_MAX))
                return false;

            int qtdDiasVencimento = CalcularDiasVencimento(creditoSignature.DataPrimeiroVencimento);
            if (!(qtdDiasVencimento > creditoParam.QTD_DIAS_VENCIMENTO_MIN) || !(qtdDiasVencimento <= creditoParam.QTD_DIAS_VENCIMENTO_MAX))
                return false;

            return true;
        }

        public decimal CalcularTaxaJurosSimples(ICreditoSignature creditoSignature, CreditoParam param)
        {            
            var valor = creditoSignature.ValorCredito;
            var taxa = param.VALOR_TAXA_PERCENTUAL;
            var tempo = creditoSignature.QuantidadeParcelas;

            var juros = valor * (taxa / 100) * tempo;           

            return juros;
        }

        public decimal CalcularValorTotal(decimal juros, decimal valor_inicial)
        {
            return  valor_inicial + juros;
        }

        private int CalcularDiasVencimento(DateTime data)
        {
            return (int)data.Subtract(DateTime.Today).TotalDays;            
        }

    }
}
