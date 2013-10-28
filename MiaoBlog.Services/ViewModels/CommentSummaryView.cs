using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.ViewModels
{
    public class CommentSummaryView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public DateTime CommentTime { get; set; }
        public string Content { get; set; }
        public int ArticleId { get; set; }
    }
}
