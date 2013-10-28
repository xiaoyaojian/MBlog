using MiaoBlog.Controllers.ActionArguments;
using MiaoBlog.Controllers.ViewModels.Account;
using MiaoBlog.Infrastructure.Authentication;
using MiaoBlog.Services.Implementations;
using MiaoBlog.Services.Interfaces;
using MiaoBlog.Services.Messaging.UserService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MiaoBlog.Controllers.Controllers
{
    public class AccountRegisterController:BaseAccountController
    {
        public AccountRegisterController(
                    ILocalAuthenticationService authenticationService,
                    IUserService userService,
                    IFormsAuthentication formsAuthentication,
                    IActionArguments actionArguments)
            :base(authenticationService,userService,formsAuthentication,actionArguments)
        {
            
        }

        public ActionResult Register()
        {
            AccountView accountView=initializeAccountViewWithIssue(false,String.Empty);
            return View(accountView);
        }

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            Account account;
            string password=collection[FormDataKeys.Password.ToString()];
            string email=collection[FormDataKeys.Email.ToString()];
            string name=collection[FormDataKeys.Name.ToString()];

            try
            {
                account=authenticationService.RegisterUser(email,password);  
            }
            catch(InvalidOperationException ex)
            {
                AccountView accountView=initializeAccountViewWithIssue(true,ex.Message);
                return View(accountView);
            }
            if(account.IsAuthenticated)
            {
                try
                {
                    CreateUserRequest createUserRequest=new CreateUserRequest();
                    createUserRequest.UserIdentityToken=account.AuthenticationToken;
                    createUserRequest.Email=email;
                    createUserRequest.Name=name;
                    formsAuthentication.SetAuthenticationToken(account.AuthenticationToken);
                    userService.CreateUser(createUserRequest);
                    return RedirectToAction("Detail","User");
                }
                catch(UserInvalidException ex)
                {
                    AccountView accountView=initializeAccountViewWithIssue(true,ex.Message);
                    return View(accountView);
                }
            }
            else
            {
                AccountView accountView=initializeAccountViewWithIssue(true,"Sorry we could not authenticate you. Please try again.");
                return View(accountView);
            }
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
