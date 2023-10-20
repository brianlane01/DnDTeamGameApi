using System;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.CharacterModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;

namespace DnDTeamGame.Services.CharacterServices;

public class CharacterService : ICharacterService
{
    private readonly ApplicationDbContext _dbContext;
    private readonly int _userId;
    public CharacterService(
        // UserManager<UserEntity> userManager,
        //             SignInManager<UserEntity> signInManager,
                    ApplicationDbContext dbContext)
    {
        // var currentUser = signInManager.Context.User;
        // var userIdClaim = userManager.GetUserId(currentUser);
        // var hasValidId = int.TryParse(userIdClaim, out _userId);

        // if (hasValidId == false)
        // {
        //     throw new Exception("Attempted to build CharacterService without Id Claim.");
        // }

        _dbContext = dbContext;
    }

    public async Task<CharacterDetail?> CreateCharacterAsync(CharacterCreate request)
    {
        CharacterEntity entity = new CharacterEntity()
        {
            UserId = request.UserId,
            CharacterName = request.CharacterName,
            CharacterDescription = request.CharacterDescription,
            CharacterHealth = request.CharacterHealth,
            CharacterBaseAttackDamage = request.CharacterBaseAttackDamage,
            CharacterBaseDefense = request.CharacterBaseDefense,
            HairColorId = request.HairColorId,
            HairStyleId = request.HairStyleId,
            BodyTypeId = request.BodyTypeId,
            CharacterClassId = request.CharacterClassId,
            DateCreated = DateTimeOffset.Now
            // AbilityList = request.AbilityList,
            // ArmourList = request.ArmourList,
            // ConsumableList = request.ConsumableList,
            // VehicleList = request.VehicleList,
            // WeaponList = request.WeaponList
        };

        var newCharacterCreated = _dbContext.Characters.Add(entity);
        var characterAdded = await _dbContext.SaveChangesAsync();

        AddAbilityToCharacter(request.AbilityList, entity.CharacterId);
        AddArmourToCharacter(request.ArmourList, entity.CharacterId);
        AddConsumablesToCharacter(request.ConsumableList, entity.CharacterId);
        AddVehiclesToCharacter(request.VehicleList, entity.CharacterId);
        AddWeaponsToCharacter(request.WeaponList, entity.CharacterId);

        CharacterDetail response = new()
        {
            CharacterId = entity.CharacterId,
            CharacterName = entity.CharacterName,
            CharacterHealth = entity.CharacterHealth,
            CharacterBaseAttackDamage = entity.CharacterBaseAttackDamage,
            CharacterBaseDefense = entity.CharacterBaseDefense,
            CharacterDescription = entity.CharacterDescription, 
            HairColorName = entity.HairColor.HairColorName,
            AbilityName = AbilitiesNameList((entity.AbilitiesList).ToList())
        };

        return response;

    }

    public async Task<bool> UpdateCharacterAsync(CharacterUpdate request)
    {
        CharacterEntity? entity = await _dbContext.Characters.FindAsync(request.CharacterId);

        // if (entity?.UserId != _userId)
        // {
        //     return false;
        // }

        entity.CharacterName = request.CharacterName;
        entity.CharacterDescription = request.CharacterDescription;
        entity.CharacterHealth = request.CharacterHealth;
        entity.CharacterBaseAttackDamage = request.CharacterBaseAttackDamage;
        entity.CharacterBaseDefense = request.CharacterBaseDefense;
        entity.HairColorId = request.HairColorId;
        entity.HairStyleId = request.HairStyleId;
        entity.BodyTypeId = request.BodyTypeId;
        entity.CharacterClassId = request.CharacterClassId;

        //* Save the changes to the database and capture how many rows were updated
        int numberOfChanges = await _dbContext.SaveChangesAsync();

        //* numberOfChanges is stated to be equal to 1 because only one row is updated
        return numberOfChanges == 1;
    }

    public async Task<bool> DeleteCharacterAsync(int characterId)
    {
        var characterEntity = await _dbContext.Characters.FindAsync(characterId);
        if (characterEntity == null)
            return false;
        _dbContext.Characters.Remove(characterEntity);
        return await _dbContext.SaveChangesAsync() == 1;
    }

    public async Task<IEnumerable<CharacterListItem>> GetAllCharactersAsync()
    {
        List<CharacterListItem> characters = await _dbContext.Characters
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

    public async Task<CharacterDetail?> GetCharacterByIdAsync(int characterId)
    {
        CharacterEntity? entity = await _dbContext.Characters
            .FirstOrDefaultAsync(e => e.CharacterId == characterId);

        return entity is null ? null : new CharacterDetail
        {
            CharacterId = entity.CharacterId,
            CharacterName = entity.CharacterName,
            CharacterHealth = entity.CharacterHealth,
            CharacterBaseAttackDamage = entity.CharacterBaseAttackDamage,
            CharacterBaseDefense = entity.CharacterBaseDefense,
            CharacterDescription = entity.CharacterDescription,
            DateCreated = entity.DateCreated
        };
    }

    public List<string> AbilitiesNameList(List<AbilityEntity> abilities)
    {
        List<string> ListToReturn = new List<string>();
        foreach( var ability in abilities)
        {
            ListToReturn.Add(ability.AbilityName);
        }

        return ListToReturn;
        
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