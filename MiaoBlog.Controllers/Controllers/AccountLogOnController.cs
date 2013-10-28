using MiaoBlog.Controllers.ActionArguments;
using MiaoBlog.Controllers.ViewModels.Account;
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
    public class AccountLogOnController:BaseAccountController
    {
        public AccountLogOnController(
            ILocalAuthenticationService authenticationService,
                    IUserService userService,
                    IFormsAuthentication formsAuthentication,
                    IActionArguments actionArguments)
            :base(authenticationService,userService,formsAuthentication,actionArguments)
        {
            
        }

        public ActionResult LogOn()
        {
            AccountView accountView=initializeAccountViewWithIssue(false,string.Empty);
            return View(accountView);
        }

        [HttpPost]
        public ActionResult LogOn(string email,string password,string returnUrl)
        {
            Account account=authenticationService.Login(email,password);
            if(account.IsAuthenticated)
            {
                formsAuthentication.SetAuthenticationToken(account.AuthenticationToken);
                if(!String.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index","Home");
                }
            }
            else
            {
                AccountView accountView=initializeAccountViewWithIssue(true,"Sorry we could not log you in.Please try again.");
                accountView.CallBackSettings.ReturnUrl=GetReturnActionFrom(returnUrl).ToString();
                return View("Logon",accountView);
            }
        }

        public ActionResult ReceiveTokenAndLogon(string token,string returnUrl)
        {
           throw new NotImplementedException();
        }

        public ActionResult SingOut()
        {
            formsAuthentication.SingOut();
            return RedirectToAction("Index","Home");
        }

        private AccountView initializeAccountViewWithIssue(bool hasIssue,string message)
        {
            AccountView accountView=new AccountView();
            accountView.CallBackSettings.Action="ReceiveTokenAndLogon";
            accountView.CallBackSettings.Controller="AccountLogOn";
            accountView.HasIssue=hasIssue;
            accountView.Message=message;
            string returnUrl=actionArguments.GetValueForArgument(ActionArgumentKey.ReturnUrl);
            accountView.CallBackSettings.ReturnUrl=GetReturnActionFrom(returnUrl).ToString();
            return accountView;
        }
    }
}
