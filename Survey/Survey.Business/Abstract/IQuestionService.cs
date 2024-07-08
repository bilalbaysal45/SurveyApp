using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.QuestionDtos;

namespace Survey.Business.Abstract
{
    public interface IQuestionService
    {
        ResponseDto<QuestionDto> Create(AddQuestionDto newQuestionDto);
        ResponseDto<List<QuestionDto>> GetAll();
        ResponseDto<QuestionDto> GetById(int id);
        ResponseDto<UpdateQuestionDto> Update(UpdateQuestionDto updateQuestionDto);
        ResponseDto<List<QuestionDto>> GetQuestionsBySurveyId(int surveyId);

    }
}