using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    public class ParticipantTypeOfSport
    {
        public int ParticipantId { get; set; }
        [ForeignKey("ParticipantId")]
        public virtual Participant Participant { get; set; }
        public int TypeOfSportId { get; set; }
        [ForeignKey("TypeOfSportId")]
        public virtual TypeOfSport TypeOfSport { get; set; }
    }
}
