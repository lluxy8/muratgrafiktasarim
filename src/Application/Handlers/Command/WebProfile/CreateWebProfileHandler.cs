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
    public class CreateWebProfileHandler : IRequestHandler<CreateWebProfileCommand, IResult<CreateWebProfileResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateWebProfileHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<CreateWebProfileResult>> Handle(CreateWebProfileCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var WebProfile = _mapper.Map<Core.Entities.WebProfile>(request.Request);
            WebProfile.Id = id;

            await _unitOfWork.WebProfileRepository.AddAsync(WebProfile, cancellationToken);
            return Result<CreateWebProfileResult>.Success(new CreateWebProfileResult { Id = id });
        }
    }
}
