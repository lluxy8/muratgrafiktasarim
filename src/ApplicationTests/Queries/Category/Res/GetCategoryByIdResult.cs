using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Category.Res
{
    public class GetCategoryByIdResult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
    }
}
