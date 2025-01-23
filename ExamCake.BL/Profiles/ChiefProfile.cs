using AutoMapper;
using ExamCake.BL.DTOs.ChiefDTO;
using ExamCake.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamCake.BL.Profiles
{
    public class ChiefProfile:Profile
    {
        public ChiefProfile()
        {
            CreateMap<Chief,GetChiefDTO>().ReverseMap();
            CreateMap<Chief,PostChiefDTO>().ReverseMap();
            CreateMap<Chief,PutChiefDTO>().ReverseMap();
        }
    }
}
