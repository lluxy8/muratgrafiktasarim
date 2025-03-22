using Application.Commands.Project;
using Application.Commands.Project.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Command.Project
{
    class UpdateProjectHandler : IRequestHandler<UpdateProjectCommand, IResult<UpdateProjectResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateProjectHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<UpdateProjectResult>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _unitOfWork.ProjectRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if(project is null)
                return Result<UpdateProjectResult>.Failure(null, "Proje bulunamadı.");

            var updatedProject = _mapper.Map(request.Request, project);
            updatedProject.Id = project.Id;

            await _unitOfWork.ProjectRepository.UpdateAsync(updatedProject, cancellationToken);

            return Result<UpdateProjectResult>.Success(new UpdateProjectResult { IsUpdated = true });
        }
    }
}
