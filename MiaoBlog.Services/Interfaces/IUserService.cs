using MiaoBlog.Services.Messaging.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Interfaces
{
    public interface IUserService
    {
        CreateUserResponse CreateUser(CreateUserRequest request);
        GetUserResponse GetUser(GetUserRequest request);
        ModifyUserResponse ModifyUser(ModifyUserRequest request);
    }
}
