using Core.Entities;

namespace Infrastructure.Repositories
{
    public sealed class CategoryRepository : GenericRepository<Category>
    {
        public CategoryRepository(AppDbContext context) : base(context)
        {
        }

    }
}
