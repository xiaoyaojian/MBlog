using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Messaging.UserService
{
    public class GetUserResponse
    {
        public bool UserFound { get; set; }
        public UserView User { get; set; }
    }
}
