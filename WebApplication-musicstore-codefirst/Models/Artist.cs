using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_musicstore_codefirst.Models
{
    public class Artist
    {
        public int ArtistId { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }


        public virtual ICollection<Album> Albums { get; set; }
    }
}