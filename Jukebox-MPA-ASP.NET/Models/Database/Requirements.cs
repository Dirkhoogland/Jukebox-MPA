using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    public partial class Requirements
    {
        public int Id { get; set; }
        public string? Lijst { get; set; }
        public string? Naam { get; set; }
        public string? Beschrijving { get; set; }
        public int? Duur { get; set; }
        public string? Status { get; set; }
    }
}
