using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{
    public class Actor
    {

        public int Id { get; set; }

        public string Name { get; set; }

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Movie { get; set; }

        public string ReleaseDate { get; set; }

    }
}
