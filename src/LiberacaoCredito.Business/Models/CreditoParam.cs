using System;
using System.Collections.Generic;
using System.Text;

namespace LiberacaoCredito.Business.Models
{
    public class CreditoParam
    {
        public string TITULO { get; set; }
        public decimal VALOR_TAXA_PERCENTUAL { get; set; }
        public decimal VALOR_EMPRESTIMO_MIN { get; set; }
        public decimal VALOR_EMPRESTIMO_MAX { get; set; }
        public int  QTD_PARCELAS_MIN { get; set; }
        public int  QTD_PARCELAS_MAX { get; set; }
        public int QTD_DIAS_VENCIMENTO_MIN { get; set; }
        public int QTD_DIAS_VENCIMENTO_MAX { get; set; }
    }
}
