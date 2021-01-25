using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_musicstore_codefirst.Models
{
    public class Genre
    {
        public int GenreId { get; set; }
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }


        [Required]
        public string Name { get; set; }
    }
}