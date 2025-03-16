using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Admin.Res
{
    public class GetAllAdminsResult
    {
        public required IEnumerable<GetAdminResult> Admins { get; set; }
    }
}
