using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnerMedia.Models.Dto
{
    public class TitleDto
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }
        public string TitleNameSortable { get; set; }
        public int? TitleTypeId { get; set; }
        public int? ReleaseYear { get; set; }
        public DateTime? ProcessedDateTimeUtc { get; set; }

        public virtual ICollection<AwardDto> Awards { get; set; }
        public virtual ICollection<OtherNameDto> OtherNames { get; set; }
        public virtual ICollection<StoryLineDto> StoryLines { get; set; }
        public virtual ICollection<TitleGenreDto> TitleGenres { get; set; }
        public virtual ICollection<TitleParticipantDto> TitleParticipants { get; set; }
    }
}
