using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Jukebox_MPA_ASP.NET.Models
{
    
    [Table("Songs")]
    public class Songs
    {
        public int Id { get; set; }
        public string Name { get; set; }


    }
}
