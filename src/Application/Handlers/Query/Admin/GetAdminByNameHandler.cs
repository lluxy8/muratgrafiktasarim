using Application.Queries.Admin;
using Application.Queries.Admin.Res;
using AutoMapper;
using Core.Interfaces;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Query.Admin
{
    public class GetAdminByNameHandler : IRequestHandler<GetAdminByNameQuery, IResult<GetAdminResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAdminByNameHandler(IMapper mapper, UnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;   
        }
        public Task<IResult<GetAdminResult>> Handle(GetAdminByNameQuery request, CancellationToken cancellationToken)
        {
            var admin = _unitOfWork.AdminRepository.GetByCondition(x => x.Name == request.Name);

        }
    }
}
