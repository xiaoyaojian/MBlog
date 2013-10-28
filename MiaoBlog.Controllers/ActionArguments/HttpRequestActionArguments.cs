using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MiaoBlog.Controllers.ActionArguments
{
    public class HttpRequestActionArguments:IActionArguments
    {

        public string GetValueForArgument(ActionArgumentKey key)
        {
            return HttpContext.Current.Request.QueryString[key.ToString()];
        }
    }
}
