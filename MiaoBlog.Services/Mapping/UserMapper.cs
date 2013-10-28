using MiaoBlog.Model.Users;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Mapping
{
    public static class UserMapper
    {
        public static UserView ConvertToUserView(this User user)
        {
            UserView view = new UserView();
            view.IdentityToken = user.IdentityToken;
            view.Name = user.Name;
            view.Email = user.Email;
            return view;
        }
    }
}
