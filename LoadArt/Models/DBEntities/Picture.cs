using System;
using System.Collections.Generic;

namespace LoadArt.Models
{
    public partial class Picture
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuthorId { get; set; }
        public int? CreationYear { get; set; }
        public string Style { get; set; }
        public string Epoch { get; set; }
        public string Medium { get; set; }
        public string Plot { get; set; }
        public long? Cost { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }

        public virtual Author Author { get; set; }
    }
}
