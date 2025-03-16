using Application.Commands.Category;
using Application.Commands.Category.Req;
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
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, IResult<UpdateCategoryResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UpdateCategoryHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<UpdateCategoryResult>> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if(category is null)
                return Result<UpdateCategoryResult>.Failure(null, "Category not found.");

            var updatedCategory = _mapper.Map(request.Request, category);
            updatedCategory.Id = category.Id;

            await _unitOfWork.CategoryRepository.UpdateAsync(updatedCategory, cancellationToken);

            return Result<UpdateCategoryResult>.Success(new UpdateCategoryResult { IsUpdated = true });

        }
    }
}
