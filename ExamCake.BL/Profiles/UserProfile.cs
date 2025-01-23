using AutoMapper;
using ExamCake.BL.DTOs.UserDTOs;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<IdentityUser,LoginUserDTO>().ReverseMap();
            CreateMap<IdentityUser,RegisterUserDTO>().ReverseMap();
        }
    }
}
