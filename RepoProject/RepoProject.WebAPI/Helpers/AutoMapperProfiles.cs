using AutoMapper;
using RepoProject.Core.DTOs;
using RepoProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepoProject.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<UserRegisterDto, User>();
            CreateMap<User, UserListDto>();
        }
    }
}
