using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    public class DisciplineParticipant
    {
        public int ParticipantId { get; set; }
        [ForeignKey("ParticipantId")]
        public virtual Participant Participant { get; set; }
        public int DisciplineId { get; set; }
        [ForeignKey("DisciplineId")]
        public virtual Discipline Discipline { get; set; }
    }
}
