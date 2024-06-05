using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.SurveyDtos;

namespace Survey.Business.Abstract
{
    public interface ISurveyService
    {
        ResponseDto<SurveyDto> Create(AddSurveyDto newSurveyDto);
        ResponseDto<List<SurveyDto>> GetAll();
        ResponseDto<SurveyDto> GetById(int id); 
        ResponseDto<UpdateSurveyDto> Update(UpdateSurveyDto updateSurveyDto);
    }
}