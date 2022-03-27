using System;

namespace Rotina.Domain.Entities
{
    public class TokenEntity
    {
        public Guid IdUser { get; set; }
        public string AutenticationType { get; set; }
        public string Token { get; set; }
        public DateTime Expires { get; set; }

        public TokenEntity(Guid idUser, string atutenticationType, string token, DateTime expires)
        {
            IdUser = idUser;
            AutenticationType = atutenticationType;
            Token = token;  
            Expires = expires;
        }
    }
}
