using System.Collections.Generic;

namespace Rotina.Domain.Entities
{
    public class RetornoEntity
    {
        public string Mensagem { get; set; }
        public List<string> Erros { get; set; }

        public RetornoEntity(string mensagem, List<string> erros)
        {
            Mensagem = mensagem;    
            Erros = erros;
        }
    }
}
