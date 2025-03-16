using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public sealed class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
