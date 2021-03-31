using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using Web_API.Model;
using Web_API.Model.Dto;

namespace Web_API.Repositories
{
    public class TitlesRepository : ITitlesRepository
    {
        private IMapper mapper;
        private TitlesContext context;

        public TitlesRepository(IConfiguration config)
        {
            var mapperConfig = new MapperConfiguration(cfg => {
                cfg.CreateMap<Title, TitleDto>();
                cfg.CreateMap<Award, AwardDto>();
                cfg.CreateMap<StoryLine, StoryLineDto>();
                cfg.CreateMap<OtherName, OtherNameDto>();
                cfg.CreateMap<TitleParticipant, TitleParticipantDto>();
                cfg.CreateMap<Participant, ParticipantDto>();
                cfg.CreateMap<TitleGenre, TitleGenreDto>();
                cfg.CreateMap<Genre, GenreDto>();
            });

            mapper = mapperConfig.CreateMapper();

            var connectionString = config.GetConnectionString("local");
            context = new ContextHelper<TitlesContext>().BuildContext(connectionString);
        }

        public ICollection<TitleDto> GetTitleDtos()
        {
            var response = context.Titles.ToArray();
            var mappedResponse = mapper.Map<ICollection<Title>, ICollection<TitleDto>>(response);
            return mappedResponse;
        }


        public TitleDto GetDetailDto(int titleId)
        {
            var response = context.Titles.Where(x => x.TitleId == titleId)
                .Include(x => x.StoryLines)
                .Include(x => x.OtherNames)
                .Include(x => x.TitleGenres)
                .ThenInclude(x => x.Genre)
                .Single();

            var mappedResponse = mapper.Map<Title, TitleDto>(response);
            return mappedResponse;
        }

        public ICollection<AwardDto> GetAwardDtos(int titleId)
        {
            var response = context.Awards.Where(x => x.TitleId == titleId).ToArray();
            var mappedResponse = mapper.Map<ICollection<Award>, ICollection<AwardDto>>(response);
            return mappedResponse;
        }

        public ICollection<TitleParticipantDto> GetTitleParticipantDtos(int titleId)
        {
            var response = context.TitleParticipants
                .Include(x => x.Participant)
                .Where(x => x.TitleId == titleId).ToArray();

            var mappedResponse = mapper.Map<ICollection<TitleParticipant>, ICollection<TitleParticipantDto>>(response);
            return mappedResponse;
        }

        public ICollection<OtherNameDto> GetOtherNameDtos(int titleId)
        {
            var response = context.OtherNames.Where(x => x.TitleId == titleId).ToArray();
            var mappedResponse = mapper.Map<ICollection<OtherName>, ICollection<OtherNameDto>>(response);
            return mappedResponse;
        }
    }
}
