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
    public record GetAllWebProfilesQuery : IRequest<IResult<IEnumerable<GetWebProfileResult>>>;
}
