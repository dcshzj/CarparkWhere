using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarparkWhere.Models.Users;

namespace CarparkWhere.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Entities.User, User>();
            CreateMap<Registration, Entities.User>();
        }
    }
}
