using MiaoBlog.Controllers.ActionArguments;
using MiaoBlog.Infrastructure.Authentication;
using MiaoBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiaoBlog.Controllers.Controllers
{
    public class BaseAccountController:Controller
    {
        protected readonly ILocalAuthenticationService authenticationService;
        protected readonly IUserService userService;
        protected readonly IFormsAuthentication formsAuthentication;
        protected readonly IActionArguments actionArguments;


        public BaseAccountController(
                    ILocalAuthenticationService authenticationService,
                    IUserService userService,
                    IFormsAuthentication formsAuthentication,
                    IActionArguments actionArguments)
        {
            this.authenticationService = authenticationService;
            this.userService = userService;
            this.formsAuthentication = formsAuthentication;
            this.actionArguments = actionArguments;
        }

        public ActionResult RedirectBasedOn(string returnUrl)
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionArgumentKey GetReturnActionFrom(string returnUrl)
        {
            return ActionArgumentKey.GoToAccount;
        }
    }
}
