using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WarnerMedia.Models.Dto
{
    public class TitleGenreDto
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int GenreId { get; set; }
        public virtual GenreDto Genre { get; set; }
    }
}
