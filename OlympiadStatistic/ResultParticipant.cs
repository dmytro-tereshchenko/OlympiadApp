using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OlympiadApp
{
    public class ResultParticipant
    {
        [Key, Required]
        public int Id { get; set; }
        [Required]
        public int ParticipantId { get; set; }
        [ForeignKey("ParticipantId")]
        public virtual Participant Participant { get; set; }
        [Required]
        public int DisciplineId { get; set; }
        [ForeignKey("DisciplineId")]
        public virtual Discipline Discipline { get; set; }
        [Column(TypeName = "smallint")]
        public int? Position { get; set; }
        [NotMapped]
        public string ResultView { get => $"{Discipline.Name} - {Participant.FullName}"; }
    }
}
