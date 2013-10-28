using MiaoBlog.Model.Comments;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Mapping
{
    public static class CommentMapper
    {
        public static CommentSummaryView ConvertToCommentSummaryView(this Comment comment)
        {
            CommentSummaryView view = new CommentSummaryView();
            view.Id = comment.Id;
            view.Email = comment.Email;
            view.Content = comment.Content;
            view.CommentTime = comment.CommentTime;
            view.ArticleId = comment.ArticleId;
            return view;
        }

        public static IEnumerable<CommentSummaryView> ConvertToCommentSummaryViews(this IEnumerable<Comment> comments)
        {
            List<CommentSummaryView> views = new List<CommentSummaryView>();
            foreach (Comment comment in comments)
            {
                views.Add(comment.ConvertToCommentSummaryView());
            }
            return views;
        }
    }
}
