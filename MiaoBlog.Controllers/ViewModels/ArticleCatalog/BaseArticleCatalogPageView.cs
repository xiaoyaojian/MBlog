using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Controllers.ViewModels.ArticleCatalog
{
    public abstract class BaseArticleCatalogPageView
    {
        public IEnumerable<CategoryView> Categories { get; set; } 
  
    }
}
