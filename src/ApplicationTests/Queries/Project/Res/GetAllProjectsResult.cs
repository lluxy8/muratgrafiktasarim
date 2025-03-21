namespace Application.Queries.Project.Res
{
    public class GetAllProjectsResult
    {
        public IEnumerable<GetProjectByIdResult> Projects { get; set; } = [];
    }
} 