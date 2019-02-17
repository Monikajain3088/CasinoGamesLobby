using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GetGameCollectionsSP
    {

        [Key]
        public int GameRelationshipId { get; set; }
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string SubCollectionName { get; set; }
        public int SubCollectionId { get; set; }       
        public int GameCollectionId { get; set; }
        public string GameCollectionName { get; set; }

    }
}
