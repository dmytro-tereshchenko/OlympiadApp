using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    [Index("FirstName", IsUnique = false, Name = "Index_FirstName")]
    [Index("LastName", IsUnique = false, Name = "Index_LastName")]
    public class Participant
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(30), Required]
        public string FirstName { get; set; }
        [MaxLength(30)]
        public string MiddleName { get; set; }
        [MaxLength(30), Required]
        public string LastName { get; set; }
        public int? CountryId { get; set; }
        [ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public virtual List<ParticipantTypeOfSport> ParticipantTypeOfSports { get; set; } = new List<ParticipantTypeOfSport>();
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        public virtual List<DisciplineParticipant> DisciplineParticipants { get; set; } = new List<DisciplineParticipant>();
        public virtual List<ResultParticipant> ResultParticipants { get; set; } = new List<ResultParticipant>();
        [NotMapped]
        public string FullName { get => $"{FirstName} {(MiddleName is null ? "" : MiddleName + " ")}{LastName}"; }
    }
}
