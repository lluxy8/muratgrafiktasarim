using Application.Commands.Project;
using Application.Commands.Project.Req;
using Application.Queries.Project;
using Application.Queries.Project.Req;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProjectController : Controller
    {
        private readonly IMediator _mediator;

        public ProjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllProjectsQuery();
            var result = await _mediator.Send(query);
            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProjectRequest request)
        {
            var command = new CreateProjectCommand(request);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return View(request);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var query = new GetProjectByIdQuery(new GetProjectByIdRequest { Id = id });
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
                return RedirectToAction(nameof(Index));

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateProjectRequest request)
        {
            var command = new UpdateProjectCommand(request);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return View(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteProjectCommand(new DeleteProjectRequest { Id = id });
            var result = await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
} 