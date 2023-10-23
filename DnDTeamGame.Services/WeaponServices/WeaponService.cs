using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.WeaponModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.WeaponServices
{
    public class WeaponService : IWeaponService
    {
        private readonly ApplicationDbContext _dbContext;

        public WeaponService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}