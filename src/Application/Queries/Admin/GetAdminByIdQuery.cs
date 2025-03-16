using Application.Queries.Admin.Req;
using Application.Queries.Admin.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.Admin
{
    public record GetAdminByIdQuery(GetAdminByIdRequest Request) : IRequest<IResult<GetAdminResult>>;
}
