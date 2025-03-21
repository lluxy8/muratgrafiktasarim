using Application.Commands.WebProfile;
using Application.Commands.WebProfile.Res;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Command.WebProfile
{
    public class DeleteWebProfileHandler : IRequestHandler<DeleteWebProfileCommand, IResult<DeleteWebProfileResult>>
    {
        private readonly UnitOfWork _unitOfWork;

        public DeleteWebProfileHandler(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IResult<DeleteWebProfileResult>> IRequestHandler<DeleteWebProfileCommand, IResult<DeleteWebProfileResult>>.Handle(DeleteWebProfileCommand request, CancellationToken cancellationToken)
        {
            var webProfile = await _unitOfWork.WebProfileRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if(webProfile is null)
                return Result<DeleteWebProfileResult>.Failure(null, "Web Profile bulunamadı");

            await _unitOfWork.WebProfileRepository.DeleteAsync(webProfile, cancellationToken);

        }
    }
}
