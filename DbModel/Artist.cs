using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_M4P3
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public string InstagrameUrl {get; set; }
        public virtual List<ArtistSong> ArtistSongs { get; set; }

    }
}
