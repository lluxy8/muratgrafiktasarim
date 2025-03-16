using Application.Queries.Project;
using Application.Queries.Project.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;

namespace Application.Handlers.Query.Project
{
    public class GetAllProjectsHandler : IRequestHandler<GetAllProjectsQuery, IResult<GetAllProjectsResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllProjectsHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<GetAllProjectsResult>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var projects = await _unitOfWork.ProjectRepository.ListAllAsync(cancellationToken);
            var projectsMap = _mapper.Map<IEnumerable<Core.Entities.Project>, IEnumerable<GetProjectByIdResult>>(projects);

            return Result<GetAllProjectsResult>.Success(new GetAllProjectsResult { Projects = projectsMap });
        }
    }
} 