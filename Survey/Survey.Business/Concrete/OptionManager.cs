using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Business.Abstract;
using Survey.Data.Abstract;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.OptionDtos;

namespace Survey.Business.Concrete
{
    public class OptionManager : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        private readonly IMapper _mapper;

        public OptionManager(IOptionRepository optionRepository, IMapper mapper)
        {
            _optionRepository = optionRepository;
            _mapper = mapper;
        }

        public ResponseDto<OptionDto> Create(AddOptionDto addOptionDto)
        {
            var option = _mapper.Map<Option>(addOptionDto);
            try
            {
                option.CreatedDate = DateTime.Now;
                var response = _optionRepository.Create(option);
                if (response != null)
                {
                    return new ResponseDto<OptionDto> { Data = _mapper.Map<OptionDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {
                return new ResponseDto<OptionDto> { Data = null, Error = "System Error" };
            }


            return new ResponseDto<OptionDto> { Data = null, Error = "Not Created" };
        }

        public ResponseDto<List<OptionDto>> GetAll()
        {
            var optionDtos = new ResponseDto<List<OptionDto>>();
            var options = new List<Option>();
            try
            {
                options = _optionRepository.GetAll();
                if (options.Count != 0)
                {
                    optionDtos.Data = _mapper.Map<List<OptionDto>>(options);
                    optionDtos.Error = null;
                    return optionDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<OptionDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<OptionDto>> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<OptionDto> GetById(int id)
        {
            var optionDto = new ResponseDto<OptionDto>();
            var option = new Option();
            try
            {
                option = _optionRepository.GetById(id);
                if (option != null)
                {
                    optionDto.Data = _mapper.Map<OptionDto>(option);
                    optionDto.Error = null;
                    return optionDto;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<OptionDto> { Data = null, Error = "System Error" };
            }
            return new ResponseDto<OptionDto> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<UpdateOptionDto> Update(UpdateOptionDto updateOptionDto)
        {
            var option = _mapper.Map<Option>(updateOptionDto);

            try
            {
                option.ModifiedDate = DateTime.Now;
                var response = _optionRepository.Update(option);
                if (response != null)
                {
                    return new ResponseDto<UpdateOptionDto> { Data = _mapper.Map<UpdateOptionDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<UpdateOptionDto> { Data = null, Error = "System Error" };
            }
            return new ResponseDto<UpdateOptionDto> { Data = null, Error = "Update Fail Somehow" };
        }
    }
}