using Application.Commands.WebProfile.Req;
using Application.Commands.WebProfile.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.WebProfile
{
    public record UpdateWebProfileCommand(UpdateWebProfileRequest Request) : IRequest<IResult<UpdateWebProfileResult>>;
}
