using MiaoBlog.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiaoBlog.Model.ArticleTags;

namespace MiaoBlog.Model.Tags
{
    public class Tag:EntityBase<int>,IAggregateRoot
    {
        public string Name { get; set; }
        public virtual IList<Article_Tag> ArticleTags { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
