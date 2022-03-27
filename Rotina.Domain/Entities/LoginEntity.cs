using System;

namespace Rotina.Domain.Entities
{
    public class LoginEntity : EntityBase
    {
        public Guid IdUser { get; set; }
        public DateTime Date { get; set; }
        public string Ip { get; set; }

        public LoginEntity()
        {

        }

        public LoginEntity(Guid idUser, string ip)
        {
            Id = Guid.NewGuid();
            IdUser = idUser;
            Date = DateTime.Now;
            Ip = ip;
        }
    }
}
