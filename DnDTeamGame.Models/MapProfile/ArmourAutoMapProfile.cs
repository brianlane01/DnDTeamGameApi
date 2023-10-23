using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.ArmourModels;

namespace DnDTeamGame.Models.MapProfile
{
    public class ArmourAutoMapProfile : Profile
    {
        public ArmourAutoMapProfile()
        {
            CreateMap<ArmourEntity, ArmourDetail>();
            CreateMap<ArmourEntity, ArmourList>();

            //! Map from the Create to ArmourEntity
            CreateMap<ArmourCreate, ArmourEntity>();
            CreateMap<ArmourUpdate, ArmourEntity>();
        }
    }
}