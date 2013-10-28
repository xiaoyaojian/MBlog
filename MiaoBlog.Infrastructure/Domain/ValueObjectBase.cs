using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Domain
{
    public abstract class ValueObjectBase
    {
        private List<BusinessRule> brokenRules = new List<BusinessRule>();


        public ValueObjectBase()
        {

        }

        protected abstract void Validate();

        public void ThrowExceptionIfInvalid()
        {
            brokenRules.Clear();
            Validate();
            if (brokenRules.Count() > 0)
            {
                StringBuilder issues = new StringBuilder();
                foreach (BusinessRule businessRule in brokenRules)
                {
                    issues.AppendLine(businessRule.Rule);
                }
                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }

        protected void AddBrokenRule(BusinessRule businessRule)
        {
            brokenRules.Add(businessRule);
        }
    }
}
