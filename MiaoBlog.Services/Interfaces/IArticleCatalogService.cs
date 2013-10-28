using MiaoBlog.Services.Messaging.ArticleCatalogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Interfaces
{
    public interface IArticleCatalogService
    {
        GetArticlesByCategoryResponse GetArticlesByCategory(GetArticlesByCategoryRequest request);
        GetArticleResponse GetArticle(GetArticleRequest request);
        GetAllCategoriesResponse GetAllCategories();
        GetArticlesResponse GetArticles(GetArticlesRequest request);
    }
}
