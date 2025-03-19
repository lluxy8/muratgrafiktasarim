using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class WebProfileRepository : GenericRepository<WebProfile>
    {
        public WebProfileRepository(AppDbContext context) : base(context)
        {
        }
    }
}
