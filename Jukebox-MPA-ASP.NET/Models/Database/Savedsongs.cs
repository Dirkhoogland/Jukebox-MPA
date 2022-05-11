using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Savedsongs
    {
        public int Id { get; set; }
        public string? Song { get; set; }
        public string? User { get; set; }
    }
}
