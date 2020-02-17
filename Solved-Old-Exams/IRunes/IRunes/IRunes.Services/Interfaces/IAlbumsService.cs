using IRunes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.Services.Interfaces
{
    public interface IAlbumsService
    {
        void Create(string name, string cover);

        IQueryable<Album> GetAll();

        Album GetAlbumById(string id);
    }
}
