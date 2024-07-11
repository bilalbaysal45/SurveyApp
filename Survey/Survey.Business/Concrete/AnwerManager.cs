using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Business.Abstract;
using Survey.Data.Abstract;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.AnswerDtos;

namespace Survey.Business.Concrete
{
    public class AnwerManager : IAnswerService
    {
        private readonly IAnswerRepository _answerRepository;
        private readonly IMapper _mapper;

        public AnwerManager(IAnswerRepository answerRepository, IMapper mapper)
        {
            _answerRepository = answerRepository;
            _mapper = mapper;
        }

        public ResponseDto<AnswerDto> Create(AddAnswerDto newAnswerDto)
        {
            var answer = _mapper.Map<Answer>(newAnswerDto);
            try
            {
                answer.CreatedDate = DateTime.Now;
                var response = _answerRepository.Create(answer);
                if (response != null)
                {
                    return new ResponseDto<AnswerDto> { Data = _mapper.Map<AnswerDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {
                return new ResponseDto<AnswerDto> { Data = null, Error = "System Error" };
            }


            return new ResponseDto<AnswerDto> { Data = null, Error = "Not Created" };
        }

        public ResponseDto<List<AnswerDto>> GetAll()
        {
            var answerDtos = new ResponseDto<List<AnswerDto>>();
            var answers = new List<Answer>();
            try
            {
                answers = _answerRepository.GetAll();
                if (answers.Count != 0)
                {
                    answerDtos.Data = _mapper.Map<List<AnswerDto>>(answers);
                    answerDtos.Error = null;
                    return answerDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<AnswerDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<AnswerDto>> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<AnswerDto> GetById(int id)
        {
            var answerDto = new ResponseDto<AnswerDto>();
            var answer = new Answer();
            try
            {
                answer = _answerRepository.GetById(id);
                if (answer != null)
                {
                    answerDto.Data = _mapper.Map<AnswerDto>(answer);
                    answerDto.Error = null;
                    return answerDto;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<AnswerDto> { Data = null, Error = "System Error" };
            }
            return new ResponseDto<AnswerDto> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<UpdateAnswerDto> Update(UpdateAnswerDto updateAnswerDto)
        {
            var answer = _mapper.Map<Answer>(updateAnswerDto);
            try
            {
                answer.ModifiedDate = DateTime.Now;
                var response = _answerRepository.Update(answer);
                if (response != null)
                {
                    return new ResponseDto<UpdateAnswerDto> { Data = _mapper.Map<UpdateAnswerDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<UpdateAnswerDto> { Data = null, Error = "System Error" };
            }
            return new ResponseDto<UpdateAnswerDto> { Data = null, Error = "Update Fail Somehow" };
        }
    }
}