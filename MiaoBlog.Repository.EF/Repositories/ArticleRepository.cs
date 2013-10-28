using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Model.Articles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.Repositories
{
    public class ArticleRepository:Repository<Article,int>,IArticleRepository
    {
        public ArticleRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { 
            
        }

        public override IQueryable<Article> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Article>();
        }

        public override string GetEntitySetName()
        {
            return "Article";
        }

        public override Article FindBy(int Id)
        {
            return GetObjectSet().FirstOrDefault(a => a.Id == Id);
        }

        public override System.Data.Objects.ObjectQuery<Article> TranslateIntoObjectQueryFrom(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Article> FindBy(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> FindBy(Infrastructure.Querying.Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Article> FindByCategoryId(int categoryId, int skip, int count)
        {
            if (categoryId != 0)
            {
                return GetObjectSet().Where(a => a.CategoryId == categoryId).OrderByDescending(a => a.CreateTime).Skip(skip).Take(count);
            }
            else
            {
                return GetObjectSet().OrderByDescending(a => a.CreateTime).Skip(skip).Take(count);
            }
        }
    }
}
