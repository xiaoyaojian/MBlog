using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Model.ArticleTags;
using MiaoBlog.Model.Categories;
using MiaoBlog.Model.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Articles
{
    public class Article:EntityBase<int>,IAggregateRoot
    {
        public string Title { get; set; }
        public DateTime CreateTime { get; set; }
        public string Content { get; set; }
        public bool Visable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual IList<Article_Tag> ArticleTags { get; set; }
        


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
