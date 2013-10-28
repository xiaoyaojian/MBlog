using MiaoBlog.Infrastructure.UnitOfWork;
using MiaoBlog.Model.Tags;
using MiaoBlog.Model.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.Repositories
{
    public class UserRepository : Repository<User, int>, IUserRepository
    {
        public UserRepository(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        { 
            
        }


        public override IQueryable<User> GetObjectSet()
        {
            return DataContextFactory.GetDataContext().CreateObjectSet<User>();
        }

        public override string GetEntitySetName()
        {
            return "User";
        }

        public override User FindBy(int Id)
        {
            return GetObjectSet().Where(u => u.Id == Id).FirstOrDefault();
        }

        public override System.Data.Objects.ObjectQuery<User> TranslateIntoObjectQueryFrom(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tag> FindByCorrelationIds(IEnumerable<int> correlationIds)
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

        public User FindBy(string identityToken)
        {
            return GetObjectSet().FirstOrDefault(u => u.IdentityToken == identityToken);
        }


        IEnumerable<User> Infrastructure.Domain.IReadOnlyRepository<User, int>.FindBy(Infrastructure.Querying.Query query)
        {
            throw new NotImplementedException();
        }

        IEnumerable<User> Infrastructure.Domain.IReadOnlyRepository<User, int>.FindBy(Infrastructure.Querying.Query query, int index, int count)
        {
            throw new NotImplementedException();
        }

    }
}
