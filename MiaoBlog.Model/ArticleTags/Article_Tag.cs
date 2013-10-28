using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Model.Articles;
using MiaoBlog.Model.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.ArticleTags
{
    public class Article_Tag : EntityBase<int>, IAggregateRoot
    {
        public int ArticleId { get; set; }
        public int TagId { get; set; }

        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
