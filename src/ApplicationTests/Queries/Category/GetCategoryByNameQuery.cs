using Application.Queries.Category.Req;
using Application.Queries.Category.Res;
using Core.Interfaces;
using MediatR;

namespace Application.Queries.Category
{
    public record GetCategoryByNameQuery(GetCategoryByNameRequest Request) : IRequest<IResult<GetCategoryByIdResult>>;
} 