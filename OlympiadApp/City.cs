using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OlympiadApp
{
    public class City
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; }
        public virtual List<CityOlympiad> CityOlympiads { get; set; } = new List<CityOlympiad>();
        [Required]
        public int CountryId { get; set; }
        //[ForeignKey("CountryId")]
        public virtual Country Country { get; set; }
    }
}
