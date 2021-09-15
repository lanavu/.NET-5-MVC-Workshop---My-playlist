using Microsoft.AspNetCore.Mvc;
using MyPlaylist.ViewModels;

namespace MyPlaylist.Controllers
{
    public class PlaylistController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Playlist";
            
            var model = new PlaylistViewModel();
            model.Name = "Mine favoritter";
            model.Playlist = new SampleTracks().GetAllTracks();

            return View(model);
        }
    }
}