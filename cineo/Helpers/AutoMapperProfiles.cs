using AutoMapper;
using cineo.Dtos;
using cineo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cineo.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserForDetailDto>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<UserForUpdateDto, User>();
        }
    }
}
