using IRunes.App.ViewModels.Tracks;
using IRunes.Services.Interfaces;
using SIS.HTTP;
using SIS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace IRunes.App.Controllers
{
    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = new CreateViewModel() { AlbumId = albumId };

            return this.View(viewModel);
        }
        
        [HttpPost]
        public HttpResponse Create(CreateTrackInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (input.Name.Length < 4 || input.Name.Length > 20)
            {
                return this.Redirect($"/Tracks/Create?albumId={input.AlbumId}");
            }

            this.tracksService.Create(input.Name, input.Link, input.Price, input.AlbumId);

            return this.Redirect("/Home/Index");
        }

        public HttpResponse Details(string albumId, string trackId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var track = this.tracksService.GetById(trackId);

            var viewModel = new TrackDetailsViewModel()
            {
                AlbumId = albumId,
                Name = track.Name,
                Price = track.Price,
                Link = track.Link
            };

            return this.View(viewModel);
        }
    }
}
