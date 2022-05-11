using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Playlists
    {
        public int Id { get; set; }
        public string? Playlist { get; set; }
        public string? Song { get; set; }
        public string? User { get; set; }
    }
}
