using Application.Queries.Project;
using Application.Queries.Project.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;

namespace Application.Handlers.Query.Project
{
    public class GetProjectByNameHandler : IRequestHandler<GetProjectByNameQuery, IResult<GetProjectByIdResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProjectByNameHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<GetProjectByIdResult>> Handle(GetProjectByNameQuery request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByConditionAsync(x => x.Title == request.Request.Name, cancellationToken);
            if (project is null)
                return Result<GetProjectByIdResult>.Failure(null, "Project not found");

            var projectMap = _mapper.Map<GetProjectByIdResult>(project);
            return Result<GetProjectByIdResult>.Success(projectMap);
        }
    }
} 