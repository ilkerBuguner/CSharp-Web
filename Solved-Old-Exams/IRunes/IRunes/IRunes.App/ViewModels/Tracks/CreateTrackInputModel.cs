using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App.ViewModels.Tracks
{
    public class CreateTrackInputModel
    {
        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public string AlbumId { get; set; }
    }
}
