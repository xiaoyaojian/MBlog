using MiaoBlog.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF
{
    public class EFUnitOfWork:IUnitOfWork
    {
        public void RegisterAmended(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            unitOfWorkRepository.PersistUpdateOf(entity);
        }

        public void RegisterNew(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            unitOfWorkRepository.PersistCreationOf(entity);
        }

        public void RegisterRemoved(Infrastructure.Domain.IAggregateRoot entity, IUnitOfWorkRepository unitOfWorkRepository)
        {
            unitOfWorkRepository.PersistDeletionOf(entity);
        }

        public void Commit()
        {
            DataContextFactory.GetDataContext().SaveChanges();
        }
    }
}
