using Application.Queries.Req;
using Application.Queries.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries
{
    public record GetAdminByIdQuery(GetAdminByIdRequest Request) : IRequest<IResult<GetAdminByIdResult>>;
}
