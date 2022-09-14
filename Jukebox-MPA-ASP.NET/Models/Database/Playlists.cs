using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Playlists
    {
        public int Id { get; set; }
        public int Playlist { get; set; }
        public string? Song { get; set; }
        public string? User { get; set; }

        public virtual Playlistname PlaylistNavigation { get; set; } = null!;
    }
}
