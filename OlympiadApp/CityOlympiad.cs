using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OlympiadApp
{
    public class CityOlympiad
    {
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        public int OlympiadYear { get; set; }
        [ForeignKey("OlympiadYear")]
        public virtual Olympiad Olympiad { get; set; }
    }
}
