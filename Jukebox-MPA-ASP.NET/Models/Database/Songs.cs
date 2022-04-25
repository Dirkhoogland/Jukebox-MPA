using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Songs
    {
        public int Id { get; set; }
        public string? Song { get; set; }
        public string? Genre { get; set; }
    }
}
