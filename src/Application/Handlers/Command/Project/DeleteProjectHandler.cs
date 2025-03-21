using Application.Commands.Project;
using Application.Commands.Project.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;

namespace Application.Handlers.Command.Project
{
    public class DeleteProjectHandler : IRequestHandler<DeleteProjectCommand, IResult<DeleteProjectResult>>
    {
        private readonly UnitOfWork _unitOfWork;

        public DeleteProjectHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IResult<DeleteProjectResult>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if (project is null)
                return Result<DeleteProjectResult>.Failure(null, "Proje bulunamadý.");

            await _unitOfWork.ProjectRepository.DeleteAsync(project, cancellationToken);

            if(File.Exists(project.ImageUrl))
                File.Delete(project.ImageUrl);

            return Result<DeleteProjectResult>.Success(new DeleteProjectResult { IsDeleted = true });
        }
    }
} 