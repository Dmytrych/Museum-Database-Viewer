using System;
using System.Collections.Generic;

namespace LoadArt.Models
{
    public partial class Worker
    {
        public Worker()
        {
            Excursions = new HashSet<Excursion>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual ICollection<Excursion> Excursions { get; set; }
    }
}
