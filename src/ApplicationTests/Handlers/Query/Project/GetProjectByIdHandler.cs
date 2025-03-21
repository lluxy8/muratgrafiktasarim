using Application.Queries.Project;
using Application.Queries.Project.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;

namespace Application.Handlers.Query.Project
{
    public class GetProjectByIdHandler : IRequestHandler<GetProjectByIdQuery, IResult<GetProjectByIdResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetProjectByIdHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<GetProjectByIdResult>> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if (project is null)
                return Result<GetProjectByIdResult>.Failure(null, "Project not found");

            var projectMap = _mapper.Map<GetProjectByIdResult>(project);
            return Result<GetProjectByIdResult>.Success(projectMap);
        }
    }
} 