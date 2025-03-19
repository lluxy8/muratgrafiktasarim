using Application.Commands.Project;
using Application.Commands.Project.Res;
using Application.Common.FileManager;
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
        private readonly ImageFileManager _imageFileManager;

        public CreateProjectHandler(UnitOfWork unitOfWork, IMapper mapper, ImageFileManager imageFileManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _imageFileManager = imageFileManager;
        }

        public async Task<IResult<CreateProjectResult>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var imageUrl = _imageFileManager.Upload(request.Request.File);

            if (imageUrl is null)
            {
                return Result<CreateProjectResult>.Failure(null, "Failed to upload image");
            }

            var id = Guid.NewGuid();
            var project = _mapper.Map<Core.Entities.Project>(request.Request);
            project.Id = id;
            project.ImageUrl = imageUrl;

            await _unitOfWork.ProjectRepository.AddAsync(project, cancellationToken);
            return Result<CreateProjectResult>.Success(new CreateProjectResult { Id = id });
        }
    }
} 