using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.ConsumableModels;

namespace DnDTeamGame.Models.MapProfile
{
    public class ConsumableAutoMapProfile : Profile
    {
        public ConsumableAutoMapProfile()
        {
            CreateMap<ConsumableEntity, ConsumableDetail>();
            CreateMap<ConsumableEntity, ConsumableList>();

            //! Map from the Create to ConsumableEntity
            CreateMap<ConsumableCreate, ConsumableEntity>();
            CreateMap<ConsumableUpdate, ConsumableEntity>();
        }
    }
}