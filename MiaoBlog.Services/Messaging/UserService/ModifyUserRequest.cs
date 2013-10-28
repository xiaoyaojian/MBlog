using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.UserService
{
    public class ModifyUserRequest
    {
        public string UserIndentityToken { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
