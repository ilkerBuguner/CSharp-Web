using IRunes.Data;
using IRunes.Models;
using IRunes.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services
{
    public class AlbumsService : IAlbumsService
    {
        private readonly RunesDbContext db;

        public AlbumsService(RunesDbContext db)
        {
            this.db = db;
        }
        public void Create(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
                Price = 0.0M
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public Album GetAlbumById(string id)
        {
            return this.db.Albums.Include(a => a.Tracks).FirstOrDefault(a => a.Id == id);
        }

        public IQueryable<Album> GetAll()
        {
            return this.db.Albums;
        }
    }
}
