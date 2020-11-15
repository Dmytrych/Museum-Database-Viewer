using System;
using System.Collections.Generic;

namespace LoadArt.Models
{
    public partial class Excursion
    {
        public Excursion()
        {
            Visitors = new HashSet<Visitor>();
        }

        public int Id { get; set; }
        public DateTime ExcursionDate { get; set; }
        public int GuideWorkerId { get; set; }

        public virtual Worker GuideWorker { get; set; }
        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}
