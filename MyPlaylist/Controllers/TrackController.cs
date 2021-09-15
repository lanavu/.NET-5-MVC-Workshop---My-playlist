using Microsoft.AspNetCore.Mvc;

namespace MyPlaylist.Controllers
{
    public class TrackController : Controller
    {
        public IActionResult Index(int id)
        {
            var track = new SampleTracks().GetTrackById(id);
            return View(track);
        }
    }
}