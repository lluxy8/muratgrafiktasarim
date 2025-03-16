using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Queries.Admin.Req;
using Application.Queries.Admin.Res;
using Core.Interfaces;
using MediatR;

namespace Application.Queries.Admin
{
    public record GetAdminByNameQuery(GetAdminByNameRequest Request) : IRequest<IResult<GetAdminResult>>;
}
