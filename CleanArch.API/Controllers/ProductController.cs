using CleanArch.Application.Features.Product.Commands.CreateProduct;
using CleanArch.Application.Wrappers;
using CleanArch.Application.Features.Product.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Documentation
        /// <summary>
        /// For product creating
        /// </summary>
        /// <remarks>
        /// <ul>
        /// <li><b>Type:</b><p>0 - New, 1 - Sold</p></li>>
        /// </ul>  
        /// </remarks>
        /// <param name="request"></param>
        [ProducesResponseType(typeof(Response), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status500InternalServerError)]
        #endregion
        [HttpPost]
        public async Task<Response> CreateProductAsync(CreateProductCommand request)
        => await _mediator.Send(request);

    }
}
