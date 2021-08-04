using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OlympiadApp
{
    public class Discipline
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int TypeOfSportId { get; set; } 
        [ForeignKey("TypeOfSportId")]
        public virtual TypeOfSport TypeOfSport { get; set; }
        [NotMapped]
        public int? AmountOfParticipants { get => DisciplineParticipants.Count; }
        [Required]
        public int OlympiadYear { get; set; }
        [ForeignKey("OlympiadYear")]
        public virtual Olympiad Olimpiad { get; set; } 
        public virtual List<DisciplineParticipant> DisciplineParticipants { get; set; } = new List<DisciplineParticipant>();
        public virtual List<ResultParticipant> ResultParticipants { get; set; } = new List<ResultParticipant>();
        [NotMapped]
        public string Name { get => $"{TypeOfSport.Name} {OlympiadYear}"; }
    }
}
