using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.CharacterModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.CharacterServices;

public class CharacterService : ICharacterService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;
    public CharacterService(
        UserManager<UserEntity> userManager,
                    SignInManager<UserEntity> signInManager,
                    ApplicationDbContext dbContext)
    {
        var currentUser = signInManager.Context.User;
        var userIdClaim = userManager.GetUserId(currentUser);
        var hasValidId = int.TryParse(userIdClaim, out _userId);

        if (hasValidId == false)
        {
            throw new Exception("Attempted to build CharacterService without Id Claim.");
        }

        _dbContext = dbContext;
    }

    public async Task<CharacterDetail?> CreateCharacterAsync(CharacterCreate request)
    {
        CharacterEntity entity = new CharacterEntity()
        {
            UserId = _userId,
            CharacterName = request.CharacterName,
            CharacterDescription = request.CharacterDescription,
            CharacterHealth = request.CharacterHealth,
            CharacterBaseAttackDamage = request.CharacterBaseAttackDamage,
            CharacterBaseDefense = request.CharacterBaseDefense,
            // AbilityId = request.AbilityId,
            // WeaponId = request.WeaponId,
            HairColorId = request.HairColorId,
            HairStyleId = request.HairStyleId,
            BodyTypeId = request.BodyTypeId,
            CharacterClassId = request.CharacterClassId
            // ArmourId = request.ArmourId,
            // ConsumableId = request.ConsumableId,
            // VehicleId = request.VehicleId
        };

        var newCharacterCreated = _dbContext.Characters.Add(entity);
        var characterAdded = await _dbContext.SaveChangesAsync();

        // AddAbilityToCharacter(request.AbilityList, newCharacterCreated.CharacterId);
        // AddArmourToCharacter(request.ArmourList, newCharacterCreated.CharacterId);
        // AddConsumablesToCharacter(request.ConsumableList, newCharacterCreated.CharacterId);
        // AddVehiclesToCharacter(request.VehicleList, newCharacterCreated.CharacterId);
        // AddWeaponsToCharacter(request.WeaponList, newCharacterCreated.CharacterId);

        CharacterDetail response = new()
        {
            CharacterName = entity.CharacterName,
            CharacterHealth = entity.CharacterHealth,
            CharacterBaseAttackDamage = entity.CharacterBaseAttackDamage,
            CharacterBaseDefense = entity.CharacterBaseDefense,
            CharacterDescription = entity.CharacterDescription,
            // AbilityId = entity.AbilityId,
            // WeaponId = entity.WeaponId,
            // HairColorId = entity.HairColorId,
            // HairStyleId = entity.HairStyleId,
            // BodyTypeId = entity.BodyTypeId,
            // ArmourId = entity.ArmourId,
            // ConsumableId = entity.ConsumableId,
            // VehicleId = entity.VehicleId,
            // CharacterClassId = entity.CharacterClassId
        };

        return response;

    }

    public async Task<IEnumerable<CharacterListItem>> GetAllCharactersAsync()
    {
        List<CharacterListItem> characters = await _dbContext.Characters
            .Where(entity => entity.UserId == _userId)
            .Select(entity => new CharacterListItem
            {
                CharacterId = entity.CharacterId,
                CharacterName = entity.CharacterName,
                CharacterDescription = entity.CharacterDescription,
                DateCreated = entity.DateCreated
            })
            .ToListAsync();

        return characters;
    }

    public void AddAbilityToCharacter(List<int> abilityIds, int characterId)
    {
        var newCharacter = _dbContext.Characters.Include(c => c.AbilitiesList).Single(c => c.CharacterId == characterId);
        foreach (var abilityId in abilityIds)
        {
            var newAbility = _dbContext.Abilities.Find(abilityId);
            if (newAbility != null)
            {
                newCharacter.AbilitiesList.Add(newAbility);
            }
        }

        _dbContext.SaveChanges();
    }

    public void AddArmourToCharacter(List<int> armourIds, int characterId)
    {
        var newCharacter = _dbContext.Characters.Include(c => c.ArmoursList).Single(c => c.CharacterId == characterId);
        foreach (var armourId in armourIds)
        {
            var newArmour = _dbContext.Armours.Find(armourId);
            if (newArmour != null)
            {
                newCharacter.ArmoursList.Add(newArmour);
            }
        }

        _dbContext.SaveChanges();

    }

    public void AddWeaponsToCharacter(List<int> weaponIds, int characterId)
    {
        var newCharacter = _dbContext.Characters.Include(c => c.WeaponsList).Single(c => c.CharacterId == characterId);

        foreach (var weaponId in weaponIds)
        {
            var newWeapon = _dbContext.Weapons.Find(weaponId);
            if (newWeapon != null)
            {
                newCharacter.WeaponsList.Add(newWeapon);
            }
        }

        _dbContext.SaveChanges();
    }

    public void AddConsumablesToCharacter(List<int> consumableIds, int characterId)
    {
        var newCharacter = _dbContext.Characters.Include(c => c.ConsumablesList).Single(c => c.CharacterId == characterId);

        foreach (var consumableId in consumableIds)
        {
            var newConsumable = _dbContext.Consumables.Find(consumableId);
            if (newConsumable != null)
            {
                newCharacter.ConsumablesList.Add(newConsumable);
            }
        }

        _dbContext.SaveChanges();
    }

    public void AddVehiclesToCharacter(List<int> vehicleIds, int characterId)
    {
        var newCharacter = _dbContext.Characters.Include(c => c.VehiclesList).Single(c => c.CharacterId == characterId);

        foreach (var vehicleId in vehicleIds)
        {
            var newVehicle = _dbContext.Vehicles.Find(vehicleId);
            if (newVehicle != null)
            {
                newCharacter.VehiclesList.Add(newVehicle);
            }
        }

        _dbContext.SaveChanges();
    }

}