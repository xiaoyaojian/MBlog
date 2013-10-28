using MiaoBlog.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiaoBlog.Services.Messaging.ArticleCatalogService;
using MiaoBlog.Model.Articles;
using MiaoBlog.Model.Categories;
using MiaoBlog.Model.Comments;
using MiaoBlog.Model.Tags;
using MiaoBlog.Services.Mapping;
using MiaoBlog.Services.ViewModels;

namespace MiaoBlog.Services.Implementations
{
    public class ArticleCatalogService:IArticleCatalogService
    {
        private readonly IArticleRepository articleRepository;
        private readonly ICategoryRepository categoryRepository;
        private readonly ICommentRepository commentRepository;
        private readonly ITagRepository tagRepository;


        public ArticleCatalogService(IArticleRepository articleRep, ICategoryRepository categoryRep, ICommentRepository commentRep, ITagRepository tagRep)
        {
            this.articleRepository = articleRep;
            this.categoryRepository = categoryRep;
            this.commentRepository = commentRep;
            this.tagRepository = tagRep;
        }

        public GetArticlesByCategoryResponse GetArticlesByCategory(GetArticlesByCategoryRequest request)
        {
            GetArticlesByCategoryResponse response = new GetArticlesByCategoryResponse();
            List<ArticleSummaryView> views = new List<ArticleSummaryView>();
            
            IEnumerable<Article> articles = articleRepository.FindByCategoryId(request.CategoryId, request.NumberOfResultsPerPage * request.Index, request.NumberOfResultsPerPage);
            foreach (Article article in articles)
            {
                IEnumerable<int> correlationIds = article.ArticleTags.Select(a => a.Id);
                IEnumerable<Tag> tags = tagRepository.FindByCorrelationIds(correlationIds);
                ArticleSummaryView view = article.ConvertToArticleSummaryView(request.ExcerptLength, tags);
                views.Add(view);
            }
            response.Articles = views;
            response.SelectedCategory = request.CategoryId;
            response.SelectedCategoryName = categoryRepository.FindBy(request.CategoryId).Name;
            response.NumberOfArticlesFound = categoryRepository.FindBy(request.CategoryId).Articles.Count();
            response.TotalNunmberOfPages = NoOfResultPagesGiven(request.NumberOfResultsPerPage, response.NumberOfArticlesFound);
            response.CurrentPage = request.Index;
            return response;
        }

        

        private static int NoOfResultPagesGiven(int numberOfResultsPerPage, int numberOfArticlesFound)
        {
            if (numberOfArticlesFound < numberOfResultsPerPage)
            {
                return 1;
            }
            else
            {
                return (numberOfArticlesFound / numberOfResultsPerPage) + (numberOfArticlesFound % numberOfResultsPerPage);
            }
        }

        public GetArticleResponse GetArticle(GetArticleRequest request)
        {
            GetArticleResponse response = new GetArticleResponse();
            Article article = articleRepository.FindBy(request.ArticleId);
            response.Article = article.ConvertToArticleView();
            response.Comments = article.Comments.ConvertToCommentSummaryViews();
            IEnumerable<int> correlationIds = article.ArticleTags.Select(a => a.Id);
            response.Tags = tagRepository.FindByCorrelationIds(correlationIds).ComvertToTagSummaryViews();
            return response;
        }

        public GetAllCategoriesResponse GetAllCategories()
        {
            GetAllCategoriesResponse response = new GetAllCategoriesResponse();
            List<Category> categories = new List<Category>();
            foreach (Category cat in categoryRepository.FindAll())
            {
                Category category = new Category() { Id = cat.Id, Name = cat.Name + "(" + cat.Articles.Count + ")" };
                categories.Add(category);
            }
            response.Categories = categories.ConvertToCategoryViews();
            return response;
        }


        public GetArticlesResponse GetArticles(GetArticlesRequest request)
        {
            IEnumerable<Article> articles = articleRepository.FindByCategoryId(request.CategoryId, 0, request.NumberOfResult);
            GetArticlesResponse response = new GetArticlesResponse();
            response.Articles = articles.ConvertToArticleViews();
            return response;
        }
    }
}
