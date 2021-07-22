using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ado_hw_15
{
    public class Olympiad
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(TypeName="smallint")]
        public int Year { get; set; }
        [Required]
        [Column(TypeName = "bit")]
        public bool IsSummer { get; set; }
        [Required]
        public int HostCountryId { get; set; }
        [ForeignKey("HostCountryId")]
        public virtual Country HostCountry { get; set; }
        public virtual List<City> Cities { get; set; } = new List<City>();


    }
}
