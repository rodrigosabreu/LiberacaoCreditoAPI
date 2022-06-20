using System.Net;

namespace LiberacaoCredito.Business.Models
{
    public class ResponseBase
    {
        public object Response { get; set; }
        public HttpStatusCode HttpStatus { get; set; }
        public string Mensagem { get; set; }
    }
}
