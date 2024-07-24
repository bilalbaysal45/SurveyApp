using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.SurveyUserDtos;


namespace Survey.Business.Abstract
{
    public interface ISurveyUserService
    {
        ResponseDto<AddSurveyUserDto> Create(AddSurveyUserDto newSurveyUser);

    }
}