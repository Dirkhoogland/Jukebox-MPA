using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Genres
    {   //Genres model, for setting up ID genre id and genre name
        public int Id { get; set; }
        public int GenreId { get; set; }
        public string? Genre { get; set; }
    }
}
