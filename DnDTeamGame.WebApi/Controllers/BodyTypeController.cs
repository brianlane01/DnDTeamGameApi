using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnDTeamGame.Services.BodyTypeServices;
using DnDTeamGame.Models.BodyTypeModels;
using DnDTeamGame.Models.Responses;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BodyTypeController : ControllerBase
    {
        private readonly IBodyTypeService _bodyTypeService;

        public BodyTypeController(IBodyTypeService bodyTypeService)
        {
            _bodyTypeService = bodyTypeService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateBodyType([FromBody] BodyTypeCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _bodyTypeService.CreateBodyTypeAsync(request);
            if (response is not null)
                return Ok(response);
            return BadRequest(new TextResponse("Could not create BodyType"));
        }
        [HttpGet]
        public async Task<IActionResult> GetAllBodyTypes()
        {
            var BodyTypes = await _bodyTypeService.GetAllBodyTypesAsync();
            return Ok(BodyTypes);
        }
        [HttpGet("{BodyType:int}")]
        public async Task<IActionResult> GetBodyTypeId([FromRoute] int bodyType)
        {
            BodyTypeDetail? detail = await _bodyTypeService.GetBodyTypeByIdAsync(bodyType);

            return detail is not null
            ? Ok(detail)
            : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateBodyTypeId([FromBody] BodyTypeUpdate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return await _bodyTypeService.UpdateBodyTypeAsync(request)
            ? Ok("Note updated successfully.")
            : BadRequest("Note could not be updated.");
        }
        [HttpDelete("{BodyType:int}")]
        public async Task<IActionResult> DeleteBodyType([FromRoute] int BodyType)
        {
            return await _bodyTypeService.DeleteBodyTypeAsync(BodyType)
            ? Ok($"BodyType {BodyType} was deleted successfully.")
            : BadRequest($"BodyType {BodyType} could not be deleted.");
        }

    }
}
