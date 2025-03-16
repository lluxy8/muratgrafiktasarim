using Application.Commands.Admin;
using Application.Commands.Admin.Res;
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

namespace Application.Handlers
{
    public record DeleteAdminHandler : IRequestHandler<DeleteAdminCommand, IResult<DeleteAdminResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteAdminHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<DeleteAdminResult>> Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            var admin = await _unitOfWork.AdminRepository.GetByIdAsync(request.Request.Id);
            if(admin is null)
                return Result<DeleteAdminResult>.Failure(null, "Admin not found.");

            await _unitOfWork.AdminRepository.DeleteAsync(admin);

            return Result<DeleteAdminResult>.Success(new DeleteAdminResult { IsDeleted = true });
        }
    }
}
