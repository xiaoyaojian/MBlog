using MiaoBlog.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Users
{
    public class User : EntityBase<int>, IAggregateRoot
    {
        public string IdentityToken { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        protected override void Validate()
        {
            if (String.IsNullOrEmpty(Name))
            {
                base.AddBrokenRule(UserBusinessRules.NameRequired);
            }
            if (String.IsNullOrEmpty(IdentityToken))
            {
                base.AddBrokenRule(UserBusinessRules.IdentityTokenRequired);
            }
            if (!new EmailValidationSpecification().IsSatisfiedBy(Email))
            {
                base.AddBrokenRule(UserBusinessRules.EmailRequired);
            }
        }
    }
}
