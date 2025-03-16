using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Admin.Req
{
    public class GetAdminByNameRequest
    {
        public required string Name { get; set; }
    }
}
