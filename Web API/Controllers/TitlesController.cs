using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Web_API.Model;
using Microsoft.EntityFrameworkCore;
using Web_API.Model.Dto;
using AutoMapper;

namespace Web_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TitlesController : ControllerBase
    {

        private readonly ILogger<TitlesController> _logger;
        private IMapper autoMappings;
        private TitlesContext context;

        public TitlesController(ILogger<TitlesController> logger)
        {
            context = new TitlesContext();
            _logger = logger;

            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Title, TitleDto>();
                cfg.CreateMap<Award, AwardDto>();
                cfg.CreateMap<StoryLine, StoryLineDto>();
                cfg.CreateMap<OtherName, OtherNameDto>();
                cfg.CreateMap<TitleParticipant, TitleParticipantDto>();
                cfg.CreateMap<Participant, ParticipantDto>();
                cfg.CreateMap<TitleGenre, TitleGenreDto>();
                cfg.CreateMap<Genre, GenreDto>();
            });

            autoMappings = config.CreateMapper();
        }

        // GET: api/basics
        [HttpGet("basics")]
        public ICollection<Title> Get()
        {
            var response = context.Titles.ToArray();
            return response;
        }

        // GET: api/titles/detail/2
        [HttpGet("detail/{titleId}")]
        public TitleDto GetDetail(int titleId)
        {
            var response = context.Titles.Where(x => x.TitleId == titleId)
                    .Include(x => x.StoryLines)
                    .Include(x => x.OtherNames)
                    .Include(x => x.TitleGenres)
                    .ThenInclude(x => x.Genre)
                    .Single();

            var mappedResponse = autoMappings.Map<Title, TitleDto>(response);

            return mappedResponse;
        }

        // GET: api/titles/awards/2
        [HttpGet("awards/{titleId}")]
        public ICollection<AwardDto> GetAwards(int titleId)
        {
            var response = context.Awards.Where(x => x.TitleId == titleId).ToArray();

            var mappedResponse = autoMappings.Map<ICollection<Award>, ICollection<AwardDto>>(response);

            return mappedResponse;
        }        
        
        // GET: api/titles/participants/5
        [HttpGet("participants/{titleId}")]
        public ICollection<TitleParticipantDto> GetTitleParticipants(int titleId)
        {
            var response = context.TitleParticipants
                .Include(x => x.Participant)
                .Where(x => x.TitleId == titleId).ToArray();

            var mappedResponse = autoMappings.Map<ICollection<TitleParticipant>, ICollection<TitleParticipantDto>>(response);

            return mappedResponse;
        }        
        
        // GET: api/titles/othernames/6
        [HttpGet("othernames/{titleId}")]
        public ICollection<OtherNameDto> GetOtherNames(int titleId)
        {
            var response = context.OtherNames.Where(x => x.TitleId == titleId).ToArray();

            var mappedResponse = autoMappings.Map<ICollection<OtherName>, ICollection<OtherNameDto>>(response);

            return mappedResponse;
        }
    }
}
