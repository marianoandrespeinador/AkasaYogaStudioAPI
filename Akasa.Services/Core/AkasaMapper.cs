using System;
using System.Collections.Generic;
using System.Text;
using Akasa.Dto;
using Akasa.Model;
using AutoMapper;

namespace Akasa.Services.Core
{
    public abstract class AkasaMapper : Profile
    {
        public AkasaMapper()
        {
            CreateMap<User, UserGetDto>().ReverseMap();
        }
    }
}
