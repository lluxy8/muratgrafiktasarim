using Core.Entities;

namespace Infrastructure.Repositories
{
    public sealed class ProjectRepository : GenericRepository<Project>
    {
        public ProjectRepository(AppDbContext context) : base(context)
        {
        }
    }
}
