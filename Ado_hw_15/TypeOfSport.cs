using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using JetBrains.Annotations;
using JetBrains.Annotations;
using JetBrains.Annotations;
using JetBrains.Annotations;
using System;
using System.Collections.Generic;

namespace Ado_hw_15
{
    [Index("Id", IsUnique = true, Name = "Index_Id")]
    public class TypeOfSport
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        public virtual List<Participant> Participants { get; set; } = new List<Participant>();
        public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();
    }
}
