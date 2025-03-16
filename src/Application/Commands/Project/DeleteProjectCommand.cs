using Application.Commands.Project.Req;
using Application.Commands.Project.Res;
using Core.Interfaces;
using MediatR;

namespace Application.Commands.Project
{
    public record DeleteProjectCommand(DeleteProjectRequest Request) : IRequest<IResult<DeleteProjectResult>>;
} 