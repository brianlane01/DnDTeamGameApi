using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnDTeamGame.Services.HairStyleServices;
using DnDTeamGame.Models.HairStyleModels;
using DnDTeamGame.Models.Responses;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairStyleController : ControllerBase
    {
        private readonly IHairStyleService _hairSyleService;

        public HairStyleController(IHairStyleService hairStyleService)
        {
            _hairSyleService = hairStyleService;
        }
    }
}
