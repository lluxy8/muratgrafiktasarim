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

    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesQuery, IResult<GetAllCategoriesResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCategoriesHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<GetAllCategoriesResult>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _unitOfWork.CategoryRepository.ListAllAsync(cancellationToken);
            var categoriesMap = _mapper.Map<IEnumerable<Core.Entities.Category>, IEnumerable<GetCategoryByIdResult>>(categories);

            return Result<GetAllCategoriesResult>.Success(new GetAllCategoriesResult { Categories = categoriesMap });
        }
    }
}
