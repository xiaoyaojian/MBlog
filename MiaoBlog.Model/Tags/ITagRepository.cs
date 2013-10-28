using MiaoBlog.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Tags
{
    public interface ITagRepository : IReadOnlyRepository<Tag, int>
    {
        IEnumerable<Tag> FindByCorrelationIds(IEnumerable<int> correlationIds);
    }
}
