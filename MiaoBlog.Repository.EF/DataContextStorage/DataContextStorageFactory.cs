using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MiaoBlog.Repository.EF.DataContextStorage
{
    public class DataContextStorageFactory
    {
        public static IDataContextStorageContainer dataContextStorageContainer;


        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if (dataContextStorageContainer == null)
            {
                if (HttpContext.Current == null)
                {
                    throw new Exception("Thie env is not web env");
                }
                else
                {
                    dataContextStorageContainer = new HttpDataContextStorageContainer();
                }
            }
            return dataContextStorageContainer;
        }
    }
}
