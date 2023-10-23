using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.HairStyleModels;
using AutoMapper;

namespace DnDTeamGame.Models.MapProfile
{
    public class HairStyleAutoMapProfile : Profile
    {
        public HairStyleAutoMapProfile()
        {
            CreateMap<HairStyleEntity, HairStyleDetail>();
            CreateMap<HairStyleEntity, HairStyleList>();

            //! Map from the Create to HairStyleEntity
            CreateMap<HairStyleCreate, HairStyleEntity>();
            CreateMap<HairStyleUpdate, HairStyleEntity>();
        }
    }
}