using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Comments
{
    public class Comment:EntityBase<int>,IAggregateRoot
    {
        public string Email { get; set; }
        public DateTime CommentTime { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
        public virtual Article Article { get; set; }


        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
