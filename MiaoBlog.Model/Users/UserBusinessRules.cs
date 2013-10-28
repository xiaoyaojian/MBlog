using MiaoBlog.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Users
{
    public class UserBusinessRules
    {
        public static readonly BusinessRule NameRequired = new BusinessRule("Name", "A User must have a name.");
        public static readonly BusinessRule EmailRequired = new BusinessRule("Email", "A User must have a valid email address.");
        public static readonly BusinessRule IdentityTokenRequired = new BusinessRule("IdentityToken", "A User must have an indentity token.");
    }
}
