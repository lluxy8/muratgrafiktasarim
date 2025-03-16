using Application.Queries.Project.Req;
using Application.Queries.Project.Res;
using Core.Interfaces;
using MediatR;

namespace Application.Queries.Project
{
    public record GetProjectByIdQuery(GetProjectByIdRequest Request) : IRequest<IResult<GetProjectByIdResult>>;
} 