using Application.Queries.WebProfile.Req;
using Application.Queries.WebProfile.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Queries.WebProfile
{
    public record GetWebProfileByIdQuery(GetWebProfileByIdRequest Request) : IRequest<IResult<GetWebProfileByIdResult>>;
}
