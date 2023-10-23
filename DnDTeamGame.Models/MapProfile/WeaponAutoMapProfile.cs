using AutoMapper;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.WeaponModels;
namespace DnDTeamGame.Models.MapProfile
{

    public class WeaponAutoMapProfile : Profile
    {
        public WeaponAutoMapProfile()
        {
            CreateMap<WeaponEntity, WeaponList>();
            CreateMap<WeaponEntity, WeaponDetail>();
            CreateMap<WeaponCreate, WeaponEntity>();
            CreateMap<WeaponUpdate, WeaponEntity>();
        }
    }
}