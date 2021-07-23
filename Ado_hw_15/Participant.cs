using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    [Index("Id", IsUnique = true, Name = "Index_Id")]
    [Index("FirstName", IsUnique = false, Name = "Index_FirstName")]
    [Index("LastName", IsUnique = false, Name = "Index_LastName")]
    [Index("CountryId", IsUnique = false, Name = "Index_CountryId")]
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
        public virtual List<TypeOfSport> TypeOfSports { get; set; } = new List<TypeOfSport>();
        [Column(TypeName = "image")]
        public byte[] Photo { get; set; }
        public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();
        public virtual List<ResultParticipant> ResultParticipants { get; set; } = new List<ResultParticipant>();
    }
}
