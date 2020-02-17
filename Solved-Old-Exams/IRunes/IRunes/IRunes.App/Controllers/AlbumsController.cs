using IRunes.App.ViewModels.Albums;
using IRunes.App.ViewModels.Tracks;
using IRunes.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IRunes.App.Controllers
{
    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new AllAlbumsViewModel()
            {
                Albums = this.albumsService.GetAll().Select(a => new AlbumInfoViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                })
            };

            return this.View(viewModel);
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateAlbumInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect("/Albums/Create");
            }

            if (String.IsNullOrWhiteSpace(input.Cover))
            {
                return this.Redirect("/Albums/Create");
            }

            this.albumsService.Create(input.Name, input.Cover);

            return this.Redirect("/Albums/All");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var album = this.albumsService.GetAlbumById(id);

            var viewModel = new AlbumDetailsViewModel
            {
                Id = album.Id,
                Name = album.Name,
                Cover = album.Cover,
                Price = album.Price,
                Tracks = album.Tracks.Select(t => new TrackInfoViewModel
                {
                    Id = t.Id,
                    Name = t.Name
                })
            };
            
            return this.View(viewModel);
        }
    }
}
