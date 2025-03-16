namespace Application.Queries.Project.Res
{
    public class GetProjectByIdResult
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime Date { get; set; }
    }
} 