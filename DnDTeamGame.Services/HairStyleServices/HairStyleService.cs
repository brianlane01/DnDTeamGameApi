using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.HairStyleModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.HairStyleServices
{
    public class HairStyleService : IHairStyleService
    {
        private readonly ApplicationDbContext _dbContext;

        public HairStyleService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}