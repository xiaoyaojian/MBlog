using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.ViewModels
{
    public class ArticleSummaryView
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreateTime { get; set; }
        public string Excerpt { get; set; }
        public IEnumerable<TagSummaryView> Tags { get; set; } 
    }
}
