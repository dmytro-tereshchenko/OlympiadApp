using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OlympiadApp
{
    public class Country
    {
        [Key, Required]
        public int Id { get; set; }
        [MaxLength(40), Required]
        public string Name { get; set; }
        public virtual List<Olympiad> Olympiads { get; set; } = new List<Olympiad>();
        public virtual List<Participant> Participants { get; set; } = new List<Participant>();
        public virtual List<City> Cities { get; set; } = new List<City>();

    }
}
