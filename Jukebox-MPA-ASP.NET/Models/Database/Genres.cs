using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Genres
    {
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string? Genre { get; set; }
    }
}
