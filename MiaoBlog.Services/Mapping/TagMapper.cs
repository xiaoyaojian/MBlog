using MiaoBlog.Model.Tags;
using MiaoBlog.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Services.Mapping
{
    public static class TagMapper
    {
        public static TagSummaryView ConvertToTagSummaryView(this Tag tag)
        {
            TagSummaryView view = new TagSummaryView();
            view.Id = tag.Id;
            view.Name = tag.Name;
            return view;
        }

        public static IEnumerable<TagSummaryView> ComvertToTagSummaryViews(this IEnumerable<Tag> tags)
        {
            List<TagSummaryView> views = new List<TagSummaryView>();
            foreach (Tag tag in tags)
            {
                TagSummaryView view = tag.ConvertToTagSummaryView();
                views.Add(view);
            }
            return views;
        }
    }
}
