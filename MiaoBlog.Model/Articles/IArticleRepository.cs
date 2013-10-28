using MiaoBlog.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Articles
{
    public interface IArticleRepository:IReadOnlyRepository<Article,int>
    {
        IEnumerable<Article> FindByCategoryId(int categoryId, int skip, int count);
    }
}
