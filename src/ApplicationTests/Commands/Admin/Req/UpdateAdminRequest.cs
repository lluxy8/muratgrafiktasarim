using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Admin.Req
{
    public class UpdateAdminRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Password { get; set; }
    }
}
