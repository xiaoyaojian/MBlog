using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MiaoBlog.Repository.EF.DataContextStorage
{
    public class HttpDataContextStorageContainer:IDataContextStorageContainer
    {
        private string dataContextKey = "DataContext";


        public BlogDataContext GetDataContext()
        {
            BlogDataContext objectContext = null;
            if (HttpContext.Current.Items.Contains(dataContextKey))
            {
                objectContext = (BlogDataContext)HttpContext.Current.Items[dataContextKey];
            }
            return objectContext;
        }




        public void Store(BlogDataContext blogDataContext)
        {
            if (HttpContext.Current.Items.Contains(dataContextKey))
            {
                HttpContext.Current.Items[dataContextKey] = blogDataContext;
            }
            else
            {
                HttpContext.Current.Items.Add(dataContextKey, blogDataContext);
            }
        }
    }
}
