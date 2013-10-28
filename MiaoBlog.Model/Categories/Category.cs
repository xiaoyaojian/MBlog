using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Categories
{
    public class Category:EntityBase<int>,IAggregateRoot
    {
        public string Name { get; set; }
        public virtual List<Article> Articles { get; set; }
   

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
