using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.ViewModels
{
    public class ArticleView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreateTime { get; set; }
        public string Content { get; set; }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        
    }
}
