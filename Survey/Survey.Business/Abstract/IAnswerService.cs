using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.AnswerDtos;



namespace Survey.Business.Abstract
{
    public interface IAnswerService
    {
        ResponseDto<AnswerDto> Create(AddAnswerDto newAnswerDto);
        ResponseDto<List<AnswerDto>> GetAll();
        ResponseDto<AnswerDto> GetById(int id);
        ResponseDto<UpdateAnswerDto> Update(UpdateAnswerDto updateAnswerDto);
    }
}