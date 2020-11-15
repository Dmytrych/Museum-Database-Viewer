using System;
using System.Collections.Generic;

namespace LoadArt.Models
{
    public partial class Visitor
    {
        public int Id { get; set; }
        public int LastExcursionId { get; set; }
        public string Name { get; set; }

        public virtual Excursion LastExcursion { get; set; }
    }
}
