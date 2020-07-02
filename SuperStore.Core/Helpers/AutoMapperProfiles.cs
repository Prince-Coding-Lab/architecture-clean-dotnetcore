using AutoMapper;
using SuperStore.Core.Dto;
using SuperStore.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuperStore.Core.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserDto, User>().ReverseMap(); 
        }
    }
}
