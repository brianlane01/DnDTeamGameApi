using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.Models.CharacterClassModels;
using AutoMapper;

namespace DnDTeamGame.Models.MapProfile
{
    public class CharacterClassAutoMapProfile : Profile
    {
        public CharacterClassAutoMapProfile()
        {
            CreateMap<CharacterClassEntity, CharacterClassDetail>();
            CreateMap<CharacterClassEntity, CharacterClassList>();

            CreateMap<CharacterClassCreate, CharacterClassEntity>();
            CreateMap<CharacterClassUpdate, CharacterClassEntity>();
        }
    }
}