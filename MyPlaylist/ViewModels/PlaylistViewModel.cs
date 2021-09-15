

using System.Collections.Generic;
using MyPlaylist.Models;

namespace MyPlaylist.ViewModels
{
    public class PlaylistViewModel
    {
        public string Name { get; set; }
        public List<Track> Playlist { get; set; }
    }
}