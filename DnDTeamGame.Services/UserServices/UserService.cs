using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using DnDTeamGame.Models.UserModels;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;

namespace DnDTeamGame.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<UserEntity> _userManager;
        private readonly SignInManager<UserEntity> _signInManager;

        public UserService(ApplicationDbContext dbContext,
                            UserManager<UserEntity> userManager,
                            SignInManager<UserEntity> signInManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<bool> RegisterUserAsync(UserRegister model)
        {  
            if(await CheckEmailAvailability(model.Email) == false)
            {
                System.Console.WriteLine("Please Try a Different Email, Email Entered Linked To Existing Account.");
                return false;
            }

            if(await CheckUserNameAvailability(model.UserName) == false)
            {
                System.Console.WriteLine("UserName already taken please try again");
                return false; 
            }

            UserEntity entity = new UserEntity()
            {
                UserName = model.UserName,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                DateCreated = DateTime.Now
            };

            IdentityResult registerResult = await _userManager.CreateAsync(entity, model.Password);

            return registerResult.Succeeded;
        }

        private async Task<bool> CheckUserNameAvailability(string userName)
        {
            UserEntity? existingUser = await _userManager.FindByNameAsync(userName);
            return existingUser is null;
        }

        private async Task<bool> CheckEmailAvailability(string email)
        {
            UserEntity? existingUser = await _userManager.FindByEmailAsync(email);
            return existingUser is null; 
        }

        public async Task<UserDetail?> GetUserByIdAsync(int userId)
        {
            UserEntity? entity = await _dbContext.Users.FindAsync(userId);
            if(entity is null)
                return null;
            
            UserDetail detail = new UserDetail()
            {
                Id = entity.Id,
                Email = entity.Email,
                UserName = entity.UserName!,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                DateCreated = entity.DateCreated
            };
            return detail;
        }

        public async Task<bool> DeleteUserAsync(int userId)
        {
            var userEntity = await _dbContext.Users.FindAsync(userId);
            _dbContext.Users.Remove(userEntity);
            return await _dbContext.SaveChangesAsync() == 1;
        }

    }
}