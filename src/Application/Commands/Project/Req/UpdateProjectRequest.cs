namespace Application.Commands.Project.Req
{
    public class UpdateProjectRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required Guid CategoryId { get; set; }
    }
} 