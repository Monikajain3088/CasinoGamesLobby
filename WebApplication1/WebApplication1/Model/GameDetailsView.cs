using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class GameDetailsView
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Thumbnail { get; set; }
        public string CategoryName { get; set; }
        public string DeviceName { get; set; }
        public List<Gamecollection> GameCollections { get; set; }
    }
}
