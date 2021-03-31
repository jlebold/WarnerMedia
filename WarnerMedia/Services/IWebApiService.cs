using System.Collections.Generic;
using WarnerMedia.Models.Dto;

namespace WarnerMedia.Services
{
    public interface IWebApiService
    {
        public ICollection<TitleDto> GetBasics();
        public TitleDto GetTitleDetail(int titleId);
        public ICollection<AwardDto> GetAwards(int titleId);
        public ICollection<TitleParticipantDto> GetParticipants(int titleId);
        public ICollection<OtherNameDto> GetOtherNames(int titleId);
    }
}
