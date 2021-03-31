using System.Collections.Generic;
using Web_API.Model.Dto;

namespace Web_API.Repositories
{
    public interface ITitlesRepository
    {
        public ICollection<TitleDto> GetTitleDtos();
        public TitleDto GetDetailDto(int titleId);
        public ICollection<AwardDto> GetAwardDtos(int titleId);
        public ICollection<TitleParticipantDto> GetTitleParticipantDtos(int titleId);
        public ICollection<OtherNameDto> GetOtherNameDtos(int titleId);
    }
}
