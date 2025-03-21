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
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, IResult<CreateCategoryResult>>
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CreateCategoryHandler(UnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IResult<CreateCategoryResult>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = Guid.NewGuid();
            var category = _mapper.Map<Core.Entities.Category>(request.Request);
            category.Id = id;
            await _unitOfWork.CategoryRepository.AddAsync(category, cancellationToken);
            return Result<CreateCategoryResult>.Success(new CreateCategoryResult { Id = id });
        }
    }
}
