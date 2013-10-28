using MiaoBlog.Repository.EF.DataContextStorage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF
{
    public class DataContextFactory
    {
        public static BlogDataContext GetDataContext()
        {
            IDataContextStorageContainer dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();
            BlogDataContext blogDataContext = dataContextStorageContainer.GetDataContext();
            if (blogDataContext == null)
            {
                blogDataContext = new BlogDataContext();
                dataContextStorageContainer.Store(blogDataContext);
            }
            return blogDataContext;
        }
    }
}
