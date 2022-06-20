using LiberacaoCredito.Business.Models;
using Dapper;
using System.Data.SqlClient;
using System.Linq;
using LiberacaoCredito.Business.Interfaces;

namespace LiberacaoCredito.Data.Repositorio
{
    public class CreditoRepositorio: ICreditoRepositorio
    {
        private string conn = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=InstituicaoFinanceiraDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";              

        public CreditoParam ObterParametrosCredito(ICreditoSignature CreditoSignature)
        {
            string query = "select " +
                    "TITULO, " +
                    "DESCRICAO, " +
                    "VALOR_TAXA_PERCENTUAL, " +
                    "VALOR_EMPRESTIMO_MIN, " +
                    "VALOR_EMPRESTIMO_MAX, " +
                    "QTD_PARCELAS_MIN, " +
                    "QTD_PARCELAS_MAX, " +
                    "QTD_DIAS_VENCIMENTO_MIN, " +
                    "QTD_DIAS_VENCIMENTO_MAX " +
                "from TB_TIPO_CREDITO TC " +
                $"inner join TB_PARAMETRO_CREDITO PC on PC.ID_TIPO_CREDITO = TC.ID_TIPO_CREDITO and TC.TITULO = '{CreditoSignature.TipoCredito}' and TC.ATIVO = 1";

            using (SqlConnection conexao = new SqlConnection(conn))
            {
                return conexao.Query<CreditoParam>(query).FirstOrDefault();

            }
        }

    }
}
