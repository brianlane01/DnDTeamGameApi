using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnDTeamGame.Services.WeaponServices;
using DnDTeamGame.Models.WeaponModels;
using DnDTeamGame.Models.Responses;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly IWeaponService _weaponService;

        public WeaponController(IWeaponService weaponService)
        {
            _weaponService = weaponService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateWeapon([FromBody] WeaponCreate request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var response = await _weaponService.CreateWeaponAsync(request);
            if(response is not null)
                return Ok(response);

            return BadRequest(new TextResponse("Could not create weapon! Please try again!"));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWeapons()
        {
            var weapons = await _weaponService.GetAllWeaponsAsync();
            return Ok(weapons);
        }

        [HttpGet("{weaponId:int}")]
        public async Task<IActionResult> GetWeaponsById([FromRoute] int weaponId)
        {
            WeaponDetail? detail = await _weaponService.GetWeaponByIdAsync(weaponId);

            return detail is not null
                ? Ok(detail)
                : NotFound();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWeaponById([FromBody] WeaponUpdate request)
        {
            if (!ModelState.IsValid)
             return BadRequest(ModelState);

            return await _weaponService.UpdateWeaponsAsync(request)
                ? Ok("Weapon was updated successfully!")
                : BadRequest("Please try again");
        }

        [HttpDelete("{weaponId:int}")]
        public async Task<IActionResult> DeleteWeaponById([FromRoute] int weaponId)
        {
            return await _weaponService.DeleteWeaponsAsync(weaponId)
                ? Ok($"Weapon: {weaponId} was successfully deleted!")
                : BadRequest("Please try again!");
        }
    }
}
