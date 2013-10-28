using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Model.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.Repositories
{
    public class CategoryRepository:Repository<Category,int>,ICategoryRepository
    {
        public CategoryRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { 
            
        }

        public override Model.Categories.Category FindBy(int id)
        {
            return GetObjectSet().FirstOrDefault<Category>(c => c.Id == id);
        }

        public override IQueryable<Category> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Category>();
        }


        public IEnumerable<Model.Categories.Category> FindBy(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Model.Categories.Category> FindBy(Infrastructure.Querying.Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public override string GetEntitySetName()
        {
            return "Category";
        }

        public override System.Data.Objects.ObjectQuery<Category> TranslateIntoObjectQueryFrom(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }
    }
}
