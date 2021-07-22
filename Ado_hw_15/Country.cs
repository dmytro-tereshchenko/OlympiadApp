using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ado_hw_15
{
    public class Country
    {
        public int Id { get; set; }
        [MaxLength(40)]
        [Required]
        public string Name { get; set; }

    }
}
