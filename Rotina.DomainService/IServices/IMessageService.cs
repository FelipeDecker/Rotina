using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.DomainService.IServices
{
    public interface IMessageService
    {
        Task<bool> SendEmail();

        Task<bool> SendSms();

        Task<bool> SendWhatsApp();
    }
}
