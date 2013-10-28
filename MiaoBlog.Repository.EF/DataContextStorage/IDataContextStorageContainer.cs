using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Repository.EF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        BlogDataContext GetDataContext();
        void Store(BlogDataContext blogDataContext);
    }
}
