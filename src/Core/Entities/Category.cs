namespace Core.Entities
{
    public class Category
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public IEnumerable<Project> Projects { get; set; } = [];
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
