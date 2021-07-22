using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    public class Discipline
    {
        public int Id { get; set; }
        public int? TypeOfSportId { get; set; } 
        [ForeignKey("TypeOfSportId")]
        public virtual TypeOfSport TypeOfSport { get; set; }
        public virtual List<Participant> Participants { get; set; } = new List<Participant>();
        public int? GoldMedalParticipantId { get; set; }
        [ForeignKey("GoldMedalParticipantId")]
        public virtual Participant GoldMedalParticipant { get; set; }
        public int? SilverMedalParticipantId { get; set; }
        [ForeignKey("SilverMedalParticipantId")]
        public virtual Participant SilverMedalParticipant { get; set; }
        public int? BronzeMedalParticipantId { get; set; }
        [ForeignKey("BronzeMedalParticipantId")]
        public virtual Participant BronzeMedalParticipant { get; set; }
    }
}
