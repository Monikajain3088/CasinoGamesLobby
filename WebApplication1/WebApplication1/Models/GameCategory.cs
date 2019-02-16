using System;
using System.Collections.Generic;

namespace WebApplication1.Models
{
    public partial class GameCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
    }
}
