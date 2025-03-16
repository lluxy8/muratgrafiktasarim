using Application.Commands.Category;
using Application.Commands.Category.Req;
using Application.Queries.Category;
using Application.Queries.Category.Req;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllCategoriesQuery();
            var result = await _mediator.Send(query);
            return View(result.Data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            var command = new CreateCategoryCommand(request);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return View(request);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(Guid id)
        {
            var query = new GetCategoryByIdQuery(new GetCategoryByIdRequest { Id = id });
            var result = await _mediator.Send(query);
            if (!result.IsSuccess)
                return RedirectToAction(nameof(Index));

            return View(result.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCategoryRequest request)
        {
            var command = new UpdateCategoryCommand(request);
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return View(request);

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCategoryCommand(new DeleteCategoryRequest { Id = id });
            var result = await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
} 