using IRunes.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.Services.Interfaces
{
    public interface ITracksService
    {
        void Create(string name, string link, decimal price, string albumId);

        Track GetById(string id);
    }
}
