using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Controllers.ViewModels.Account
{
    public class AccountView
    {
        public CallBackSettings CallBackSettings { get; set; }
        public bool HasIssue { get; set; }
        public string Message { get; set; }


        public AccountView()
        {
            CallBackSettings = new CallBackSettings();
        }
    }
}
