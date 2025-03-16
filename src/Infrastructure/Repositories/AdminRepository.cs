using Core.Entities;

namespace Infrastructure.Repositories
{
    public sealed class AdminRepository : GenericRepository<Admin>
    {
        public AdminRepository(AppDbContext context) : base(context)
        {
        }
    }
}
