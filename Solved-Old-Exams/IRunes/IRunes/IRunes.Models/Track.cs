using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IRunes.Models
{
    public class Track
    {
        public Track()
        {
            Id = Guid.NewGuid().ToString();
        }

        public string Id { get; set; }

        [MinLength(4), MaxLength(20), Required]
        public string Name { get; set; }

        [Required]
        public string Link { get; set; }

        [Required]
        public decimal Price { get; set; }

        [ForeignKey("Album")]
        public string AlbumId { get; set; }

        public Album Album { get; set; }
    }
}
