using MiaoBlog.Infrastructure.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiaoBlog.Model.Comments
{
    public interface ICommentRepository : IReadOnlyRepository<Comment, int>
    {

    }
}
