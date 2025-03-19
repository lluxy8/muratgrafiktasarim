namespace Core.Entities
{
    public class Project
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public required Category Category { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
