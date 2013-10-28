using MiaoBlog.Controllers.ViewModels.UserAccount;
using MiaoBlog.Infrastructure.Authentication;
using MiaoBlog.Services.Interfaces;
using MiaoBlog.Services.Messaging.UserService;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiaoBlog.Controllers.Controllers
{
    [Authorize]
    public class UserController:Controller
    {
        private readonly IUserService userService;
        private readonly IFormsAuthentication formsAuthentication;


        public UserController(IUserService userService, IFormsAuthentication formsAuthentication)
        {
            this.userService = userService;
            this.formsAuthentication = formsAuthentication;
        }

        public ActionResult Detail()
        {
            GetUserRequest userRequest = new GetUserRequest();
            userRequest.UserIdentityToken = formsAuthentication.GetAuthenticationToken();
            GetUserResponse response = userService.GetUser(userRequest);
            UserDetailView userDetailView = new UserDetailView();
            userDetailView.User = response.User;
            return View(userDetailView);
        }

        [HttpPost]
        public ActionResult Detail(UserView userView)
        {
            ModifyUserRequest request = new ModifyUserRequest();
            request.UserIndentityToken = formsAuthentication.GetAuthenticationToken();
            request.Name = userView.Name;
            request.Email = userView.Email;
            ModifyUserResponse response = userService.ModifyUser(request);
            UserDetailView userDetailView = new UserDetailView();
            userDetailView.User = response.User;
            return View(userDetailView);
        }
    }
}
