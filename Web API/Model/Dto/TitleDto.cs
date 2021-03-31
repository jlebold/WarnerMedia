using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Model.Dto
{
    public class TitleDto
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUtc { get; set; }

        public ICollection<AwardDto> Awards { get; set; }
        public ICollection<OtherNameDto> OtherNames { get; set; }
        public ICollection<StoryLineDto> StoryLines { get; set; }
        public ICollection<TitleGenreDto> TitleGenres { get; set; }
        public ICollection<TitleParticipantDto> TitleParticipants { get; set; }
    }
}
