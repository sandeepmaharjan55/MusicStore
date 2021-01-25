using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication_musicstore_codefirst.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        public string CartId { get; set; }

        public int AlbumId { get; set; }

        public int Count { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }=DateTime.Now;

        public virtual Album Album { get; set; }

    }
}