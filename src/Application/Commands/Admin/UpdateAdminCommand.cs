using Application.Commands.Admin.Req;
using Application.Commands.Admin.Res;
using Core.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Admin
{
    public record UpdateAdminCommand(UpdateAdminRequest Request) : IRequest<IResult<UpdateAdminResult>>;
}
