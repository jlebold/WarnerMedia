using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_API.Model.Dto
{
    public class TitleParticipantDto
    {
        public int Id { get; set; }
        public int TitleId { get; set; }
        public int ParticipantId { get; set; }
        public bool IsKey { get; set; }
        public string RoleType { get; set; }
        public bool IsOnScreen { get; set; }
        public ParticipantDto Participant { get; set; }
    }
}
