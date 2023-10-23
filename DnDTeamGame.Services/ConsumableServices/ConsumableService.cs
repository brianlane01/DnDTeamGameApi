using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.ConsumableModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.ConsumableServices
{
    public class ConsumableService : IConsumableService
    {
        private readonly ApplicationDbContext _dbContext;

        public ConsumableService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}