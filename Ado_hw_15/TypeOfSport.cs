using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ado_hw_15
{
    public class TypeOfSport
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public virtual List<Participant> Participants { get; set; } = new List<Participant>();
        public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();

    }
}
