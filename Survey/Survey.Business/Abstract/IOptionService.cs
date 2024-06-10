using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.OptionDtos;

namespace Survey.Business.Abstract
{
    public interface IOptionService
    {
        ResponseDto<OptionDto> Create(AddOptionDto addOptionDto);
        ResponseDto<List<OptionDto>> GetAll();
        ResponseDto<OptionDto> GetById(int id);
        ResponseDto<UpdateOptionDto> Update(UpdateOptionDto updateOptionDto);
    }
}