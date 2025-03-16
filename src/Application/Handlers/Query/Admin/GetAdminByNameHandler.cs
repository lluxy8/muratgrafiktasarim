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
    public class GetAdminByNameHandler : IRequestHandler<GetAdminByNameQuery, IResult<GetAdminByIdResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdminByNameHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<GetAdminByIdResult>> Handle(GetAdminByNameQuery request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.GetByConditionAsync(x => x.Name == request.Request.Name, cancellationToken);
            if (admin is null)
                return Result<GetAdminByIdResult>.Failure(null, "Admin not found");

            var adminMap = _mapper.Map<GetAdminByIdResult>(admin);
            return Result<GetAdminByIdResult>.Success(adminMap);
        }
    }
}
