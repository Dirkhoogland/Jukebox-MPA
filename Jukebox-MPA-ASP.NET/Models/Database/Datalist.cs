using System;
using System.Collections.Generic;

namespace Jukebox_MPA_ASP.NET.Models.Database
{
    //data list model for setting up id and name for users 
    public partial class Datalist
    {
        public int Id { get; set; }

        public string? Name { get; set; }
    }
}
