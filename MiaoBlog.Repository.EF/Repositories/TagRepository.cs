using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Model.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.Repositories
{
    public class TagRepository:Repository<Tag,int>,ITagRepository
    {
        public TagRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { 
            
        }

        public override IQueryable<Tag> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Tag>();
        }

        public override string GetEntitySetName()
        {
            return "Tag";
        }

        public override Tag FindBy(int Id)
        {
            return GetObjectSet().FirstOrDefault(t => t.Id == Id);
        }

        public override System.Data.Objects.ObjectQuery<Tag> TranslateIntoObjectQueryFrom(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Tag> FindBy(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> FindBy(Infrastructure.Querying.Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> FindByCorrelationIds(IEnumerable<int> correlationIds)
        {
            var tags = from t in GetObjectSet()
                       where correlationIds.Contains(t.Id)
                       select t;
            return tags.AsEnumerable<Tag>();
        }
    }
}
