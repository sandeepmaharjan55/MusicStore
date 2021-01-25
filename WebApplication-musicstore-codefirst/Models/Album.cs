using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication_musicstore_codefirst.Models
{
    public class Album
    {
        [Key]
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 4)]
        public string Title { get; set; }

        [Required]
        [Range(200, 500)]

        public decimal Price { get; set; }

        [ScaffoldColumn(false)]
        public string AlbumArtUrl { get; set; }

        public int Discount { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsTrending { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [NotMapped]
        public string CreatedByName { get; set; }

        [Required]
        [Display(Name = "Genre ")]
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }


        [Display(Name = "Artist ")]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }

    }
}