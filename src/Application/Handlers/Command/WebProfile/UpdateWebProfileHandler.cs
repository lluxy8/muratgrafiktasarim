using Application.Commands.WebProfile;
using Application.Commands.WebProfile.Res;
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

namespace Application.Handlers.Command.WebProfile
{
    public class UpdateWebProfileHandler : IRequestHandler<UpdateWebProfileCommand, IResult<UpdateWebProfileResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateWebProfileHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<UpdateWebProfileResult>> Handle(UpdateWebProfileCommand request, CancellationToken cancellationToken)
        {
            var webProfile = await _unitOfWork.WebProfileRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if (webProfile is null)
                return Result<UpdateWebProfileResult>.Failure(null, "WebProfile not fund");

            var updatedWebProfile = _mapper.Map(request.Request, webProfile);
            updatedWebProfile.Id = webProfile.Id;

            await _unitOfWork.WebProfileRepository.UpdateAsync(updatedWebProfile, cancellationToken);
            return Result<UpdateWebProfileResult>.Success(new UpdateWebProfileResult{ IsUpdated = true });
        }
    }
}
