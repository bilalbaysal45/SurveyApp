using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Business.Abstract;
using Survey.Data.Abstract;
using Survey.Entity.Concrete;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.QuestionDtos;

namespace Survey.Business.Concrete
{
    public class QuestionManager : IQuestionService
    {
        private readonly IQuestionRepository _questionRepository;
        private readonly IMapper _mapper;

        public QuestionManager(IQuestionRepository questionRepository, IMapper mapper)
        {
            _questionRepository = questionRepository;
            _mapper = mapper;
        }

        public ResponseDto<QuestionDto> Create(AddQuestionDto newQuestionDto)
        {
            var question = _mapper.Map<Question>(newQuestionDto);
            try
            {
                question.CreatedDate = DateTime.Now;
                var response = _questionRepository.Create(question);
                if (response != null)
                {
                    return new ResponseDto<QuestionDto> { Data = _mapper.Map<QuestionDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {
                return new ResponseDto<QuestionDto> { Data = null, Error = "System Error" };
            }


            return new ResponseDto<QuestionDto> { Data = null, Error = "Not Created" };
        }

        public ResponseDto<List<QuestionDto>> GetAll()
        {
            var questionDtos = new ResponseDto<List<QuestionDto>>();
            var questions = new List<Question>();
            try
            {
                questions = _questionRepository.GetAll();
                if (questions.Count != 0)
                {
                    questionDtos.Data = _mapper.Map<List<QuestionDto>>(questions);
                    questionDtos.Error = null;
                    return questionDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<QuestionDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<QuestionDto>> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<QuestionDto> GetById(int id)
        {
            var questionDto = new ResponseDto<QuestionDto>();
            var question = new Question();
            try
            {
                question = _questionRepository.GetById(id);
                if (question != null)
                {
                    questionDto.Data = _mapper.Map<QuestionDto>(question);
                    questionDto.Error = null;
                    return questionDto;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<QuestionDto> { Data = null, Error = "System Error" };
            }
            return new ResponseDto<QuestionDto> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<UpdateQuestionDto> Update(UpdateQuestionDto updateQuestionDto)
        {
            var question = _mapper.Map<Question>(updateQuestionDto);

            try
            {
                question.ModifiedDate = DateTime.Now;
                var response = _questionRepository.Update(question);
                if (response != null)
                {
                    return new ResponseDto<UpdateQuestionDto> { Data = _mapper.Map<UpdateQuestionDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<UpdateQuestionDto> { Data = null, Error = "System Error" };
            }
            return new ResponseDto<UpdateQuestionDto> { Data = null, Error = "Update Fail Somehow" };
        }
    }
}