using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using DnDTeamGame.Services.ConsumableServices;
using DnDTeamGame.Models.ConsumableModels;
using DnDTeamGame.Models.Responses;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumableController : ControllerBase
    {
        private readonly IConsumableService _consumableService;

        public ConsumableController(IConsumableService consumableService)
        {
            _consumableService = consumableService;
        }
    }
}
