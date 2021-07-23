using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    [Index("Year", IsUnique = true, Name = "Index_Year_Key")]
    [Index("HostCountryId", IsUnique = false, Name = "Index_HostCountryId")]
    public class Olympiad
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None), Required, Column(TypeName="smallint")]
        public int Year { get; set; }
        [Required, Column(TypeName = "bit")]
        public bool IsSummer { get; set; }
        [Required]
        public int HostCountryId { get; set; }
        [ForeignKey("HostCountryId")]
        public virtual Country HostCountry { get; set; }
        public virtual List<City> Cities { get; set; } = new List<City>();
        public virtual List<Discipline> Disciplines { get; set; } = new List<Discipline>();

    }
}
