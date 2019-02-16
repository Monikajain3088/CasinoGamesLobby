using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class GameCollections
    {
        public GameCollections()
        {
            SubCollections = new HashSet<SubCollections>();
        }

        public int CollectionId { get; set; }
        public string Name { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual ICollection<SubCollections> SubCollections { get; set; }
    }
}
