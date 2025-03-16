using Application.Commands.Admin;
using Application.Commands.Admin.Res;
using Application.Common.Security;
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

namespace Application.Handlers.Command.Admin
{
    public class UpdateAdminHandler : IRequestHandler<UpdateAdminCommand, IResult<UpdateAdminResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateAdminHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<UpdateAdminResult>> Handle(UpdateAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if (admin is null)
                return Result<UpdateAdminResult>.Failure(null, "Admin bulunamadı");

            var updatedAdmin = _mapper.Map(request.Request, admin);
            updatedAdmin.Id = admin.Id;

            if (!string.IsNullOrEmpty(request.Request.Password))
            {
                updatedAdmin.Password = PasswordHasher.HashPassword(request.Request.Password);
            }

            await _unitOfWork.AdminRepository.UpdateAsync(updatedAdmin, cancellationToken);

            return Result<UpdateAdminResult>.Success(new UpdateAdminResult { IsUpdated = true });
        }
    }
}
