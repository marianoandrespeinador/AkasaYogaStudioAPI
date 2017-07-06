using System;
using System.Collections.Generic;
using System.Text;
using Akasa.Dto;
using Akasa.Model;
using AutoMapper;

namespace Akasa.Services.Core
{
    public class AkasaMapper : Profile
    {
        public AkasaMapper()
        {
            CreateMap<Lesson, LessonUpdateDto>().ReverseMap();
            CreateMap<Lesson, LessonInsertDto>().ReverseMap();
            CreateMap<Lesson, LessonGetDto>().ReverseMap();
        }
    }
}
