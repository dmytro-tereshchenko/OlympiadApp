using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    [Index("Id", IsUnique = true, Name = "Index_Id")]
    [Index("TypeOfSportId", IsUnique = false, Name = "Index_TypeOfSportId")]
    [Index("OlympiadId", IsUnique = false, Name = "Index_OlympiadId")]
    public class Discipline
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int TypeOfSportId { get; set; } 
        [ForeignKey("TypeOfSportId")]
        public virtual TypeOfSport TypeOfSport { get; set; }
        [NotMapped]
        public int AmountOfParticipants { get => Participants.Count; }
        [Required]
        public int OlympiadId { get; set; }
        [ForeignKey("OlympiadId")]
        public virtual Olympiad Olimpiad { get; set; } 
        public virtual List<Participant> Participants { get; set; } = new List<Participant>();
        public virtual List<ResultParticipant> ResultParticipants { get; set; } = new List<ResultParticipant>();
    }
}
