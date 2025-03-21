using Application.Commands.Category.Req;
using Application.Commands.Category.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Category
{
    public record UpdateCategoryCommand(UpdateCategoryRequest Request) : IRequest<IResult<UpdateCategoryResult>>;
}
