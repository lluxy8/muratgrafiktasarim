using Application.Commands.Admin;
using Application.Commands.Admin.Req;
using Application.Queries.Admin;
using Application.Queries.Admin.Req;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllAdminsQuery();
            var result = await _mediator.Send(query);
            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAdminRequest request)
        {
            var command = new CreateAdminCommand(request);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return View(request);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var query = new GetAdminByIdQuery(new GetAdminByIdRequest { Id = id });
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
                return RedirectToAction(nameof(Index));

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateAdminRequest request)
        {
            var command = new UpdateAdminCommand(request);
            var result = await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteAdminCommand(new DeleteAdminRequest { Id = id });
            var result = await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
} 