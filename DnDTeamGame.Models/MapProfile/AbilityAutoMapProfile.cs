using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.AbilityModels;

namespace DnDTeamGame.Models.MapProfile
{
    public class AbilityAutoMapProfile : Profile
    {
        public AbilityAutoMapProfile()
        {
            //* Map from the Entity to the Detail/List
            CreateMap<AbilityEntity, AbilityDetail>();
            CreateMap<AbilityEntity, AbilityListItem>();

            //! Map from the Create to AbilityEntity
            CreateMap<AbilityCreate, AbilityEntity>();
            CreateMap<AbilityUpdate, AbilityEntity>();
        }
    }
}