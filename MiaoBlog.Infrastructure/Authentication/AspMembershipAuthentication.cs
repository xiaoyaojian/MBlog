using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace MiaoBlog.Infrastructure.Authentication
{
    public class AspMembershipAuthentication:ILocalAuthenticationService
    {
        public Account Login(string email, string password)
        {
            Account account = new Account();
            account.IsAuthenticated = false;
            if (Membership.ValidateUser(email, password))
            {
                MembershipUser validatedUser = Membership.GetUser(email);
                account.AuthenticationToken = validatedUser.ProviderUserKey.ToString();
                account.Email = email;
                account.IsAuthenticated = true;
            }
            return account;
        }

        public Account RegisterUser(string email, string password)
        {
            MembershipCreateStatus status;
            Account account = new Account();
            account.IsAuthenticated = false;
            Membership.CreateUser(email, password, email, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), true, out status);
            if (status == MembershipCreateStatus.Success)
            {
                MembershipUser newlyCreatedUser = Membership.GetUser(email);
                account.AuthenticationToken = newlyCreatedUser.ProviderUserKey.ToString();
                account.Email = email;
                account.IsAuthenticated = true;
            }
            else
            {
                switch (status)
                { 
                    case MembershipCreateStatus.DuplicateEmail:
                        throw new InvalidOperationException("There is already a account with this email address.");
                    case MembershipCreateStatus.InvalidEmail:
                        throw new InvalidOperationException("Your email address is invalid");
                    case MembershipCreateStatus.DuplicateUserName:
                        throw new InvalidOperationException("There is already a account with this email address.");
                    default:
                        throw new InvalidOperationException("There was a problem creating your account." + "Please try again.");
                }
            }
            return account;
        }
    }
}
