using Application.Queries.Category.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Category
{
    public record GetAllCategoriesQuery() : IRequest<IResult<GetAllCategoriesResult>>;
}
