using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.HairColorModels;
using AutoMapper;

namespace DnDTeamGame.Models.MapProfile
{
    public class HairColorAutoMapProfile : Profile
    {
        public HairColorAutoMapProfile()
        {
            CreateMap<HairColorEntity, HairColorDetail>();
            CreateMap<HairColorEntity, HairColorList>();

            //! Map from the Create to HairColorEntity
            CreateMap<HairColorCreate, HairColorEntity>();
            CreateMap<HairColorUpdate, HairColorEntity>();
        }
    }
}