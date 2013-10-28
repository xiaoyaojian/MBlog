using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Infrastructure.Querying
{
    public class Query
    {
        private IList<Query> subQueries = new List<Query>();
        private IList<Criterion> criteria = new List<Criterion>();


        public IEnumerable<Criterion> Criteria
        {
            get { return this.criteria; }
        }

        public IEnumerable<Query> SubQueries
        {
            get { return this.subQueries; }
        }

        public void AddSubQuery(Query subQuery)
        {
            subQueries.Add(subQuery);
        }

        public void Add(Criterion criterion)
        {
            criteria.Add(criterion);
        }

        public QueryOperator QueryOperator { get; set; }

        public OrderByClause OrderByProperty { get; set; }
    }
}
