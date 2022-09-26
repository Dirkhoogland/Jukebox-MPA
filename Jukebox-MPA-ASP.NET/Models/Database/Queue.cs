using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Queue
    { // model for queue db 
        public int Id { get; set; }
        public int? Song { get; set; }
        public string? User { get; set; }
        public string? Songname { get; set; }
    }
}
