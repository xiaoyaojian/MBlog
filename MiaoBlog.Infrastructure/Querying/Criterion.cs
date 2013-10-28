using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Querying
{
    public class Criterion
    {
        private string propertyName;
        private object value;
        private CriteriaOperator criteriaOperator;


        public Criterion(string propertyName, object value, CriteriaOperator criteriaOperator)
        {
            this.propertyName = propertyName;
            this.value = value;
            this.criteriaOperator = criteriaOperator;
        }

        public string PropertyName
        {
            get { return this.propertyName; }
        }

        public object Value
        {
            get { return this.value; }
        }

        public CriteriaOperator CriteriaOperator
        {
            get { return this.criteriaOperator; }
        }

        public static Criterion Create<T>(Expression<Func<T, object>> expression, object value, CriteriaOperator criteriaOperator)
        {
            string propertyName = PropertyNameHelper.ResolvePropertyName<T>(expression);
            Criterion myCriterion = new Criterion(propertyName, value, criteriaOperator);
            return myCriterion;
        }
    }
}
