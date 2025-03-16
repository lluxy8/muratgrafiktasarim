using Application.Commands.Category;
using Application.Commands.Category.Res;
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

namespace Application.Handlers.Command.Category
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand, IResult<DeleteCategoryResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DeleteCategoryHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<DeleteCategoryResult>> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if(category is null)
                return Result<DeleteCategoryResult>.Failure(null, "Kategori bulunamadı");

            await _unitOfWork.CategoryRepository.DeleteAsync(category, cancellationToken);
            return Result<DeleteCategoryResult>.Success(new DeleteCategoryResult { IsDeleted = true });
        }
    }
}
