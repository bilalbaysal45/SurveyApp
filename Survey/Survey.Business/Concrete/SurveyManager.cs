using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Survey.Business.Abstract;
using Survey.Data.Abstract;
using Survey.Shared.Dtos;
using Survey.Shared.Dtos.SurveyDtos;

namespace Survey.Business.Concrete
{
    public class SurveyManager : ISurveyService
    {
        private readonly ISurveyRepository _surveyRepository;
        private readonly IMapper _mapper;

        public SurveyManager(ISurveyRepository surveyRepository, IMapper mapper)
        {
            _surveyRepository = surveyRepository;
            _mapper = mapper;
        }

        public ResponseDto<SurveyDto> Create(AddSurveyDto newSurveyDto)
        {
            var survey = _mapper.Map<Entity.Concrete.Survey>(newSurveyDto);
            try
            {
                survey.CreatedDate = DateTime.Now;
                var response = _surveyRepository.Create(survey);
                if (response != null)
                {
                    return new ResponseDto<SurveyDto> { Data = _mapper.Map<SurveyDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {
                
                return new ResponseDto<SurveyDto>{ Data=null, Error = "System Error" };
            }

            
            return new ResponseDto<SurveyDto> { Data = null, Error = "Not Created" };
        }

        public ResponseDto<List<SurveyDto>> GetAll()
        {
            var surveyDtos = new ResponseDto<List<SurveyDto>>();
            var surveys = new List<Entity.Concrete.Survey>();
            try
            {
                surveys = _surveyRepository.GetAll();
                if (surveys.Count != 0)
                {
                    surveyDtos.Data = _mapper.Map<List<SurveyDto>>(surveys);
                    surveyDtos.Error = null;
                    return surveyDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<SurveyDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<SurveyDto>> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<SurveyDto> GetById(int id)
        {
            var surveyDto = new ResponseDto<SurveyDto>();
            var survey = new Entity.Concrete.Survey();
            try
            {
            survey = _surveyRepository.GetById(id);
                if (survey != null)
                {
                    surveyDto.Data = _mapper.Map<SurveyDto>(survey);
                    surveyDto.Error = null;
                    return surveyDto;
                }
            }
            catch (System.Exception)
            {
                
                return new ResponseDto<SurveyDto>{ Data = null, Error = "System Error" };
            }
            return new ResponseDto<SurveyDto> { Data = null, Error = "Not Found" };
        }

        public ResponseDto<UpdateSurveyDto> Update(UpdateSurveyDto updateSurveyDto)
        {
            var survey = _mapper.Map<Entity.Concrete.Survey>(updateSurveyDto);

            try
            {
                survey.ModifiedDate = DateTime.Now;
                var response = _surveyRepository.Update(survey);
                if (response != null)
                {
                    return new ResponseDto<UpdateSurveyDto> { Data = _mapper.Map<UpdateSurveyDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {
                
                return new ResponseDto<UpdateSurveyDto>{ Data = null, Error = "System Error" };
            }
            return new ResponseDto<UpdateSurveyDto> { Data = null, Error = "Update Fail Somehow" };
        }
        public ResponseDto<List<SurveyDto>> GetSurveys(string userId)
        {
            var surveyDtos = new ResponseDto<List<SurveyDto>>();
            var surveys = new List<Entity.Concrete.Survey>();
            try
            {
                surveys = _surveyRepository.GetSurveys(userId);
                if (surveys.Count != 0)
                {
                    surveyDtos.Data = _mapper.Map<List<SurveyDto>>(surveys);
                    surveyDtos.Error = null;
                    return surveyDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<SurveyDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<SurveyDto>> { Data = null, Error = "Not Found" };
        }
        public ResponseDto<List<SurveyDto>> SurveyResults()
        {
            var surveyDtos = new ResponseDto<List<SurveyDto>>();
            var surveys = new List<Entity.Concrete.Survey>();
            try
            {
                surveys = _surveyRepository.SurveyResults();
                if (surveys.Count != 0)
                {
                    surveyDtos.Data = _mapper.Map<List<SurveyDto>>(surveys);
                    surveyDtos.Error = null;
                    return surveyDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<SurveyDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<SurveyDto>> { Data = null, Error = "Not Found" };
        }
        public ResponseDto<List<SurveyDto>> GetSurveysNotAnswered(string userId)
        {
            var surveyDtos = new ResponseDto<List<SurveyDto>>();
            var surveys = new List<Entity.Concrete.Survey>();
            try
            {
                surveys = _surveyRepository.GetSurveysNotAnswered(userId);
                if (surveys.Count != 0)
                {
                    surveyDtos.Data = _mapper.Map<List<SurveyDto>>(surveys);
                    surveyDtos.Error = null;
                    return surveyDtos;
                }
            }
            catch (System.Exception)
            {

                return new ResponseDto<List<SurveyDto>> { Data = null, Error = "System Excepcion" };
            }

            return new ResponseDto<List<SurveyDto>> { Data = null, Error = "Not Found" };
        }
    }
}
