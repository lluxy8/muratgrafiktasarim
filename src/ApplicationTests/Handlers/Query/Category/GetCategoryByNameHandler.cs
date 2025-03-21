using Application.Queries.Category;
using Application.Queries.Category.Res;
using AutoMapper;
using Core.Interfaces;
using Core.Models;
using Infrastructure;
using MediatR;

namespace Application.Handlers.Query.Category
{
    public class GetCategoryByNameHandler : IRequestHandler<GetCategoryByNameQuery, IResult<GetCategoryByIdResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCategoryByNameHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IResult<GetCategoryByIdResult>> Handle(GetCategoryByNameQuery request, CancellationToken cancellationToken)
        {
            var category = await _unitOfWork.CategoryRepository.GetByConditionAsync(x => x.Name == request.Request.Name, cancellationToken);
            if (category is null)
                return Result<GetCategoryByIdResult>.Failure(null, "Category not found");

            var categoryMap = _mapper.Map<GetCategoryByIdResult>(category);
            return Result<GetCategoryByIdResult>.Success(categoryMap);
        }
    }
} 