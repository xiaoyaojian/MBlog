using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Model.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.Repositories
{
    public class CommentRepository:Repository<Comment,int>,ICommentRepository
    {
        public CommentRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { 
            
        }

        public override IQueryable<Comment> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<Comment>();
        }

        public override string GetEntitySetName()
        {
            return "Comment";
        }

        public override Comment FindBy(int Id)
        {
            return GetObjectSet().FirstOrDefault(c => c.Id == Id);
        }

        public override System.Data.Objects.ObjectQuery<Comment> TranslateIntoObjectQueryFrom(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Comment> FindBy(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Comment> FindBy(Infrastructure.Querying.Query query, int index, int count)
        {
            throw new NotImplementedException();
        }
    }
}
