using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Category.Res
{
    public class GetAllCategoriesResult
    {
        public IEnumerable<GetCategoryByIdResult> Categories { get; set; } = [];
    }
}
