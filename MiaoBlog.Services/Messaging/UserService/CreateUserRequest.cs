using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.UserService
{
    public class CreateUserRequest
    {
        public string UserIdentityToken { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
