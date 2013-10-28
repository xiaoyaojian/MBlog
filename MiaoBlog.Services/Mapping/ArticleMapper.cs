using MiaoBlog.Infrastructure.Helpers;
using MiaoBlog.Model.Articles;
using MiaoBlog.Model.Comments;
using MiaoBlog.Model.Tags;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Mapping
{
    public static class ArticleMapper
    {
        public static ArticleView ConvertToArticleView(this Article article)
        {
            ArticleView view = new ArticleView();
            view.Id = article.Id;
            view.CreateTime = article.CreateTime.ToString();
            view.Content = article.Content;
            view.Title = article.Title;
            view.CategoryId = article.CategoryId;
            view.CategoryName = article.Category.Name;
            return view;
        }

        public static ArticleSummaryView ConvertToArticleSummaryView(this Article article,int excerptLength, IEnumerable<Tag> tags)
        {
            ArticleSummaryView view = new ArticleSummaryView();
            view.Id = article.Id;
            view.Title = article.Title;
            view.CreateTime = article.CreateTime.ToString();
            view.Excerpt = Translators.ExcerptTranslator(article.Content, excerptLength);
            view.Tags = tags.ComvertToTagSummaryViews();
            return view;
        }

        public static IEnumerable<ArticleView> ConvertToArticleViews(this IEnumerable<Article> articles)
        {
            List<ArticleView> views = new List<ArticleView>();
            foreach (Article article in articles)
            {
                views.Add(article.ConvertToArticleView());              
            }
            return views;
        }
    }
}
