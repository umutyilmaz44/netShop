using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using netShop.Application.Dtos;
using netShop.Application.Features.Commands.BrandCommands;
using netShop.Application.Features.Queries.BrandQueries;
using netShop.Application.Wrappers;
using netShop.WebApi.Controllers.Base;

namespace netShop.WebApi.Controllers
{
    //[Authorize]
    public class BrandsController : BaseController
    {
        /// <summary>
        /// Find record by parameters
        /// </summary>
        /// <param name="request">filter by request fields</param>
        /// <param name="page">page number for pageable result</param>
        /// <param name="size">record number per page for pageable result</param>
        /// <param name="sort">sort result Ex: fieldName1 asc, fieldName2 dec vs...</param>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedResponse<List<BrandDto>>>> Find([FromBody] FindBrandsQuery request, [FromQuery] int page = 0, int size = 10, string sort = "")
        {
            request.Page = page;
            request.PageSize = size;
            request.Sort = sort;
            var vm = await Mediator.Send(request);

            return base.Ok(vm);
        }

        [HttpGet("{id}")]
        // [AllowAnonymous]
        public async Task<ActionResult<BrandDto>> Get(Guid id)
        {
            var vm = await Mediator.Send(new GetBrandDetailQuery { Id = id });

            return base.Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Response<BrandDto>>> Create([FromBody] CreateBrandCommand request)
        {
            Response<BrandDto> response = await Mediator.Send(request);

            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Update([FromBody] UpdateBrandCommand request)
        {
            await Mediator.Send(request);

            return NoContent();
        }

        [HttpPatch("{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Patch(Guid id, [FromBody] JsonPatchDocument<BrandDto> patchDto)
        {
            PatchBrandCommand request = new PatchBrandCommand(id, patchDto, ModelState);
            await Mediator.Send(request);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Delete(Guid id)
        {
            await Mediator.Send(new DeleteBrandCommand { Id = id });

            return NoContent();
        }
    }
}