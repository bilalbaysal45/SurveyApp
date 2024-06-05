using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Shared.Dtos.SurveyDtos;

namespace Survey.Business.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            CreateMap<Entity.Concrete.Survey, SurveyDto>().ReverseMap();
            CreateMap<Entity.Concrete.Survey, AddSurveyDto>().ReverseMap();
            CreateMap<Entity.Concrete.Survey, UpdateSurveyDto>().ReverseMap();
        }
    }
}