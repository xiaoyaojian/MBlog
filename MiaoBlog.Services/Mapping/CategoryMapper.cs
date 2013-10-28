using MiaoBlog.Infrastructure.Domain;
using MiaoBlog.Model.Categories;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Mapping
{
    public static class CategoryMapper
    {
        public static IEnumerable<CategoryView> ConvertToCategoryViews(this IEnumerable<Category> categories)
        {
            IList<CategoryView> views = new List<CategoryView>();
            foreach (Category cat in categories)
            {
                CategoryView view = new CategoryView();
                view.Id = cat.Id;
                view.Name = cat.Name;
                views.Add(view);
            }
            return views;
        }
    }
}
