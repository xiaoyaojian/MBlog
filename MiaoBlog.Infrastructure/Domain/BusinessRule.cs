using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Domain
{
    public class BusinessRule
    {
        private string property;
        private string rule;


        public BusinessRule(string property, string rule)
        {
            this.property = property;
            this.rule = rule;
        }

        public string Property
        {
            get { return this.property; }
            set { this.property = value; }
        }

        public string Rule
        {
            get { return this.rule; }
            set { this.rule = value; }
        }
    }
}
