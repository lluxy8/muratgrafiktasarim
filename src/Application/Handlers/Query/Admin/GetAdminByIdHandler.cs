using Application.Queries;
using Application.Queries.Res;
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

namespace Application.Handlers.Query.Admin
{
    public class GetAdminByIdHandler : IRequestHandler<GetAdminByIdQuery, IResult<GetAdminByIdResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdminByIdHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<GetAdminByIdResult>> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if (admin is null)
                return Result<GetAdminByIdResult>.Failure(null, "Admin bulunamadı.");
            var adminMap = _mapper.Map<GetAdminByIdResult>(admin);

            return Result<GetAdminByIdResult>.Success(adminMap);
        }
    }
}
