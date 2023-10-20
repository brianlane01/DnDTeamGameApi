using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnDTeamGame.Services.CharacterServices;
using DnDTeamGame.Models.CharacterModels;
using DnDTeamGame.Models.Responses;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
    
        [HttpPost]
        public async Task<IActionResult> CreateCharacter([FromBody] CharacterCreate request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _characterService.CreateCharacterAsync(request);
            if (response is not null)
            {
                return Ok(response);
            }

            return BadRequest(new TextResponse("Could not create Character."));
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<CharacterListItem>), 200)]
        public async Task<IActionResult> GetAllCharacters()
        {
            var characters = await _characterService.GetAllCharactersAsync();
            return Ok(characters);
        }
    }
}
