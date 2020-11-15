using System;
using System.Collections.Generic;

namespace LoadArt.Models
{
    public partial class Author
    {
        public Author()
        {
            Pictures = new HashSet<Picture>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Pseudonim { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? DeathDate { get; set; }

        public virtual ICollection<Picture> Pictures { get; set; }
    }
}
