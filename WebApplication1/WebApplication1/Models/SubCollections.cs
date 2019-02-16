using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class SubCollections
    {
        public int SubCollectionId { get; set; }
        public string Name { get; set; }
        public int RefGameCollectionId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual GameCollections RefGameCollection { get; set; }
    }
}
