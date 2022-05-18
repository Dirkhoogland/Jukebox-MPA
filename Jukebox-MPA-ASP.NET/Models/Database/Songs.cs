using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Songs
    {
        public int Id { get; set; }
        public int? Duration { get; set; }
        public string? Genre { get; set; }
        public string? Author { get; set; }
        public string? Name { get; set; }
    }
}
