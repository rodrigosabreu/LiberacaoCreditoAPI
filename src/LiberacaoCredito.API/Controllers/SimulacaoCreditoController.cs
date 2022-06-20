using LiberacaoCredito.API.ViewModels;
using LiberacaoCredito.Business.Enums;
using LiberacaoCredito.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LiberacaoCredito.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SimulacaoCreditoController : ControllerBase
    {
        private readonly ICreditoService _creditoService;
        private readonly ICreditoSignature _creditoSignature;

        public SimulacaoCreditoController(ICreditoService creditoService, ICreditoSignature creditoSignature)
        {
            _creditoService = creditoService;
            _creditoSignature = creditoSignature;
        }
        
        [HttpPost("Simular")]
        public ActionResult SimulacaoCredito(SimulacaoViewModel simulacao)
        {
            _creditoSignature.TipoCredito = (TipoCredito)simulacao.TipoCredito;
            _creditoSignature.DataPrimeiroVencimento = Convert.ToDateTime(simulacao.DataPrimeiroVencimento);
            _creditoSignature.QuantidadeParcelas = simulacao.QuantidadeParcelas;
            _creditoSignature.ValorCredito = simulacao.ValorCredito;


            var resultSimulacao = _creditoService.Simular(_creditoSignature);

            return Ok(resultSimulacao);
        }

     
    }
}
