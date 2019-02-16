using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Games
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int RefDeviceId { get; set; }
        public int RefCategoryId { get; set; }
        public int RefCollectionId { get; set; }
        
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int RefSubCollectionId { get; internal set; }
    }
}
