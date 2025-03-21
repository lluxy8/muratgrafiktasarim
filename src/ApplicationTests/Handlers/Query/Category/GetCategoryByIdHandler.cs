using Application.Queries.Category;
using Application.Queries.Category.Res;
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

namespace Application.Handlers.Query.Category
{
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdQuery, IResult<GetCategoryByIdResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByIdHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<GetCategoryByIdResult>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(request.Request.Id, cancellationToken);
            if(category is null)
                return Result<GetCategoryByIdResult>.Failure(null, "Category not found");

            var categoryMap = _mapper.Map<GetCategoryByIdResult>(category);
            return Result<GetCategoryByIdResult>.Success(categoryMap);
        }
    }
}
