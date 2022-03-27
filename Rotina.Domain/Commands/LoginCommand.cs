using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotina.Domain.Commands
{
    public class LoginCommand : CommandBase
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
