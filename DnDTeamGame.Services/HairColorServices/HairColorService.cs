using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.HairColorModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace DnDTeamGame.Services.HairColorServices
{
    public class HairColorService : IHairColorService
    {
        private readonly ApplicationDbContext _dbContext;

        public HairColorService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}