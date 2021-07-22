using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ado_hw_15
{
    public class City
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        public virtual List<Olympiad> Olympiads { get; set; } = new List<Olympiad>();
    }
}
