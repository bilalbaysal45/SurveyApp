using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos.QuestionDtos;
using Survey.Shared.Dtos.SurveyDtos;

namespace Survey.Business.Mapping
{
    public class GeneralMappingProfile : Profile
    {
        public GeneralMappingProfile()
        {
            //Surveys
            CreateMap<Entity.Concrete.Survey, SurveyDto>().ReverseMap();
            CreateMap<Entity.Concrete.Survey, AddSurveyDto>().ReverseMap();
            CreateMap<Entity.Concrete.Survey, UpdateSurveyDto>().ReverseMap();

            //Questions
            CreateMap<Question, QuestionDto>().ReverseMap();
            CreateMap<Question, AddQuestionDto>().ReverseMap();
            CreateMap<Question, UpdateQuestionDto>().ReverseMap();
        }
    }
}