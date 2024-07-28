using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Survey.Business.Abstract;
using Survey.Shared.Dtos.SurveyUserDtos;
using Survey.Shared.Dtos;
using AutoMapper;
using Survey.Data.Abstract;
using Survey.Entity.Concrete;

namespace Survey.Business.Concrete
{
    public class SurveyUserManager : ISurveyUserService
    {
        private readonly ISurveyUserRepository _surveyUserRepository;
        private readonly IMapper _mapper;

        public SurveyUserManager(ISurveyUserRepository surveyUserRepository, IMapper mapper)
        {
            _surveyUserRepository = surveyUserRepository;
            _mapper = mapper;
        }

        public ResponseDto<AddSurveyUserDto> Create(AddSurveyUserDto newSurveyUser)
        {
            var surveyUser = _mapper.Map<SurveyUser>(newSurveyUser);
            var x = _surveyUserRepository.GetAll().Find(x=> x.UserId == newSurveyUser.UserId && x.SurveyId == newSurveyUser.SurveyId);
            try
            {
                if (x != null)
                {
                    return new ResponseDto<AddSurveyUserDto> { Data = null, Error = "Already Exist" };
                }
                else
                {
                    var response = _surveyUserRepository.Create(surveyUser);
                    return new ResponseDto<AddSurveyUserDto> { Data = _mapper.Map<AddSurveyUserDto>(response), Error = null };
                }
            }
            catch (System.Exception)
            {
                return new ResponseDto<AddSurveyUserDto> { Data = null, Error = "System Error" };
            }


            return new ResponseDto<AddSurveyUserDto> { Data = null, Error = "Not Created" };
        }
        public ResponseDto<UpdateSurveyUserDto> Update(UpdateSurveyUserDto updateSurveyUser)
        {
            var surveyUser = _mapper.Map<SurveyUser>(updateSurveyUser);
            try
            {
                var response = _surveyUserRepository.Update(surveyUser);
                if (response != null)
                {
                    return new ResponseDto<UpdateSurveyUserDto> { Data = _mapper.Map<UpdateSurveyUserDto>(response), Error = null };
                }
            }
            catch (Exception ex)
            {
                var innerException = ex.InnerException;
                return new ResponseDto<UpdateSurveyUserDto> { Data = null, Error = innerException.Message };
            }
            return new ResponseDto<UpdateSurveyUserDto> { Data = null, Error = "Update Fail Somehow" };
        }

    }
}