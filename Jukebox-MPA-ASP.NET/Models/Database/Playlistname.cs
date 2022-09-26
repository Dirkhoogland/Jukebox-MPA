using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Playlistname
    {   // playlistame model, with key to playlist
        public Playlistname()
        {
            Playlists = new HashSet<Playlists>();
        }

        public int Id { get; set; }
        public string Playlistname1 { get; set; } = null!;
        public string? User { get; set; }


        public virtual ICollection<Playlists> Playlists { get; set; }
    }
}
