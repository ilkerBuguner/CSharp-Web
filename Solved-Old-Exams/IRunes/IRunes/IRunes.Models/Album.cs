using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace IRunes.Models
{
    public class Album
    {
        public Album()
        {
            Id = Guid.NewGuid().ToString();
            Tracks = new HashSet<Track>();
        }

        public string Id { get; set; }

        [MinLength(4), MaxLength(20), Required]
        public string Name { get; set; }

        [Required]
        public string Cover { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Track> Tracks { get; set; }
    }
}
