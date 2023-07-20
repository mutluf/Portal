﻿using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Portal.Application.Features.Commands.Categories.CreateCategory;
using Portal.Application.Features.Commands.Categories.DeleteCategory;

namespace Portal.WebAPI.Controllers
{
    [Route("api/categories")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Organiser")]
    public class CategoriesController : ControllerBase
    {
        readonly IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Create([FromRoute] DeleteCategoryRequest request)
        {
            await _mediator.Send(request);
            return Ok();
        }
    }
}
