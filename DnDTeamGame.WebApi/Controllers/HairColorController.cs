using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnDTeamGame.Services.HairColorServices;
using DnDTeamGame.Models.HairColorModels;
using DnDTeamGame.Models.Responses;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HairColorController : ControllerBase
    {
        private readonly IHairColorService _hairColorService;

        public HairColorController(IHairColorService hairColorService)
        {
            _hairColorService = hairColorService;
        }
    }
}
