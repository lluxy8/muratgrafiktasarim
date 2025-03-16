using Application.Queries.Admin;
using Application.Queries.Admin.Res;
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
    public class GetAdminByIdHandler : IRequestHandler<GetAdminByIdQuery, IResult<GetAdminResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdminByIdHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<GetAdminResult>> Handle(GetAdminByIdQuery request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if (admin is null)
                return Result<GetAdminResult>.Failure(null, "Admin bulunamadı.");

            var adminMap = _mapper.Map<GetAdminResult>(admin);
            return Result<GetAdminResult>.Success(adminMap);
        }
    }
}
