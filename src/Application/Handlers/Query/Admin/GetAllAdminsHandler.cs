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
    public class GetAllAdminsHandler : IRequestHandler<GetAllAdminsQuery, IResult<GetAllAdminsResult>>
    {
        private readonly UnitOfWork _unitOfWork;   
        private readonly IMapper _mapper;

        public GetAllAdminsHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<GetAllAdminsResult>> Handle(GetAllAdminsQuery request, CancellationToken cancellationToken)
        {
            var admins = await _unitOfWork.AdminRepository.ListAllAsync(cancellationToken);
            var adminsMap = _mapper.Map<IEnumerable<Core.Entities.Admin>, IEnumerable<GetAdminByIdResult>>(admins);

            return Result<GetAllAdminsResult>.Success(new GetAllAdminsResult { Admins = adminsMap });
        }
    }
}
