using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Infrastructure.Querying;
using MiaoBlog.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.Repositories
{
    public abstract class Repository<T,EntityKey>:IUnitOfWorkRepository where T:IAggregateRoot
    {
        private IUnitOfWork unitOfWork;


        public Repository(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void Add(T entity)
        {
            unitOfWork.RegisterNew(entity, this);
        }

        public void Remove(T entity)
        {
            unitOfWork.RegisterRemoved(entity, this);
        }

        public void Save(T entity)
        {
            unitOfWork.RegisterAmended(entity, this);
        }

        public abstract IQueryable<T> GetObjectSet();
        public abstract string GetEntitySetName();
        public abstract T FindBy(EntityKey Id);
        public abstract ObjectQuery<T> TranslateIntoObjectQueryFrom(Query query);

        public IEnumerable<T> FindAll()
        {
            return GetObjectSet().ToList<T>();
        }

        public IEnumerable<T> FindAll(int index, int count)
        {
            return GetObjectSet().Skip(index).Take(count).ToList<T>();
        }

        public void PersistCreationOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            DataContextFactory.GetDataContext().AddObject(GetEntitySetName(), entity);
        }

        public void PersistUpdateOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            //Do nothing as EF tracks changes
        }

        public void PersistDeletionOf(Infrastructure.Domain.IAggregateRoot entity)
        {
            DataContextFactory.GetDataContext().DeleteObject(entity);
        }
    }
}
