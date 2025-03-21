using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Admin.Res
{
    public class GetAdminResult
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
    }
}
