using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Web_API.Model.Dto;
using Web_API.Repositories;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitlesController : ControllerBase
    {
        private readonly ILogger<TitlesController> logger;
        private readonly ITitlesRepository titlesRepository;

        public TitlesController(ILogger<TitlesController> logger, ITitlesRepository titlesRepository)
        {
            this.titlesRepository = titlesRepository;
            this.logger = logger;
        }

        // GET: api/titles/basics
        [HttpGet("basics")]
        public ICollection<TitleDto> GetTitles()
        {
            try
            {
                var dtos = titlesRepository.GetTitleDtos();
                return dtos;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }

        }

        // GET: api/titles/detail/2
        [HttpGet("detail/{titleId}")]
        public TitleDto GetDetail(int titleId)
        {
            try
            {
                var dto = titlesRepository.GetDetailDto(titleId);
                return dto;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }

        // GET: api/titles/awards/2
        [HttpGet("awards/{titleId}")]
        public ICollection<AwardDto> GetAwards(int titleId)
        {
            try
            {
                var dtos = titlesRepository.GetAwardDtos(titleId);
                return dtos;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }        
        
        // GET: api/titles/participants/5
        [HttpGet("participants/{titleId}")]
        public ICollection<TitleParticipantDto> GetTitleParticipants(int titleId)
        {
            try
            {
                var dtos = titlesRepository.GetTitleParticipantDtos(titleId);
                return dtos;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }
        }        
        
        // GET: api/titles/othernames/6
        [HttpGet("othernames/{titleId}")]
        public ICollection<OtherNameDto> GetOtherNames(int titleId)
        {
            try
            {
                var dtos = titlesRepository.GetOtherNameDtos(titleId);
                return dtos;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return null;
            }

        }
    }
}
