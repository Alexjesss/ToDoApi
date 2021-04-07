using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Actrice
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Movie { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
    }
}
