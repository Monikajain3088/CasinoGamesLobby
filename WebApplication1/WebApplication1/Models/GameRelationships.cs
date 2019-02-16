using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public partial class GameRelationships
    {
        [Key]
        public int GameRelationshipId { get; set; }
        public int RefGameId { get; set; }
        public int RefDeviceId { get; set; }
        public int RefCategoryId { get; set; }
        public int RefSubCollectionId { get; internal set; }
        public int RefCollectionId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }
}
