using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.BodyTypeModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.BodyTypeServices
{
    public class BodyTypeService : IBodyTypeService
    {
        private readonly ApplicationDbContext _dbContext;

        public BodyTypeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}