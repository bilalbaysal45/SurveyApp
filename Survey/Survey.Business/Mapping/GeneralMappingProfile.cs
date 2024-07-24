using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos.OptionDtos;
using Survey.Shared.Dtos.QuestionDtos;
using Survey.Shared.Dtos.QuestionOptionDtos;
using Survey.Shared.Dtos.SurveyDtos;
using Survey.Shared.Dtos.AnswerDtos;
using Survey.Shared.Dtos.SurveyUserDtos;

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

            //Options
            CreateMap<Option, OptionDto>().ReverseMap();
            CreateMap<Option, AddOptionDto>().ReverseMap();
            CreateMap<Option, UpdateOptionDto>().ReverseMap();

            //QuestionOption
            CreateMap<QuestionOption, QuestionOptionDto>().ReverseMap();

            //Answers
            CreateMap<Answer, AnswerDto>().ReverseMap();
            CreateMap<Answer, AddAnswerDto>().ReverseMap();
            CreateMap<Answer, UpdateAnswerDto>().ReverseMap();

            CreateMap<SurveyUser, AddSurveyUserDto>().ReverseMap();
        }
    }
}