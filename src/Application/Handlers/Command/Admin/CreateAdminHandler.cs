using Application.Commands.Admin;
using Application.Commands.Admin.Res;
using Application.Common.Security;
using AutoMapper;
using Core.Entities;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.Command.Admin
{
    public class CreateAdminHandler : IRequestHandler<CreateAdminCommand, IResult<CreateAdminResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateAdminHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<CreateAdminResult>> Handle(CreateAdminCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var admin = _mapper.Map<Core.Entities.Admin>(request.Request);
            admin.Id = id;
            
            // Şifreyi hashle
            admin.Password = PasswordHasher.HashPassword(request.Request.Password);

            await _unitOfWork.AdminRepository.AddAsync(admin, cancellationToken);
            return Result<CreateAdminResult>.Success(new CreateAdminResult { Id = id });
        }
    }
}
