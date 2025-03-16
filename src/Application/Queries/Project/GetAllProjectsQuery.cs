using Application.Queries.Project.Res;
using Core.Interfaces;
using MediatR;

namespace Application.Queries.Project
{
    public record GetAllProjectsQuery() : IRequest<IResult<GetAllProjectsResult>>;
} 