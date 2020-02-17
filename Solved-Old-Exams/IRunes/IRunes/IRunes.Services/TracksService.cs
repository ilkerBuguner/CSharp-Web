using IRunes.Data;
using IRunes.Models;
using IRunes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class TracksService : ITracksService
    {
        private readonly RunesDbContext db;

        public TracksService(RunesDbContext db)
        {
            this.db = db;
        }

        public void Create(string name, string link, decimal price, string albumId)
        {
            var track = new Track()
            {
                Name = name,
                Link = link,
                Price = price,
                AlbumId = albumId
            };

            this.db.Tracks.Add(track);

            var allTracksPricesSum = this.db.Tracks.Where(t => t.AlbumId == albumId)
                .Sum(t => t.Price) + price;
            var album = this.db.Albums.Find(albumId);
            album.Price = allTracksPricesSum * 0.87M;

            this.db.SaveChanges();
        }

        public Track GetById(string id)
        {
            return this.db.Tracks.FirstOrDefault(t => t.Id == id);
        }
    }
}
