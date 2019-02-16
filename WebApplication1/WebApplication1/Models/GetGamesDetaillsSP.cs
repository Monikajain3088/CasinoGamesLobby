using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class GetGamesDetaillsSP
    {
        [Key]
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string DeviceName { get; set; }
        public int GameCollectionId { get; set; }
        public string GameCollectionName { get; set; }
    }
}
