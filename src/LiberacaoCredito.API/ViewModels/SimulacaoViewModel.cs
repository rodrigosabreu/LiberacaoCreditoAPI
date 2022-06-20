namespace LiberacaoCredito.API.ViewModels
{
    public class SimulacaoViewModel
    {
        public decimal ValorCredito { get; set; }
        public int QuantidadeParcelas { get; set; }
        public int TipoCredito { get; set; }
        public string DataPrimeiroVencimento { get; set; }
    }
}
