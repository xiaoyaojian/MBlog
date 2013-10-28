using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Authentication
{
    public interface ILocalAuthenticationService
    {
        Account Login(string email, string password);
        Account RegisterUser(string email, string password);
    }
}
