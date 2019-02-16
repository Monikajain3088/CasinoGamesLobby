using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class Games
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }        
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }
}
