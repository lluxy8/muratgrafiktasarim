using Application.Commands.Project;
using Application.Commands.Project.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;

namespace Application.Handlers.Command.Project
{
    public class CreateProjectHandler : IRequestHandler<CreateProjectCommand, IResult<CreateProjectResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateProjectHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<CreateProjectResult>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var project = _mapper.Map<Core.Entities.Project>(request.Request);
            project.Id = id;
            await _unitOfWork.ProjectRepository.AddAsync(project, cancellationToken);
            return Result<CreateProjectResult>.Success(new CreateProjectResult { Id = id });
        }
    }
} 