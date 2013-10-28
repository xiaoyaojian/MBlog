using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Users
{
    public class EmailValidationSpecification
    {
        private static Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");


        public bool IsSatisfiedBy(string email)
        {
            return emailRegex.IsMatch(email);
        }
    }
}
