using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OlympiadApp
{
    public class TypeOfSport
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        public virtual List<ParticipantTypeOfSport> ParticipantTypeOfSports { get; set; } = new List<ParticipantTypeOfSport>();
        public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}
