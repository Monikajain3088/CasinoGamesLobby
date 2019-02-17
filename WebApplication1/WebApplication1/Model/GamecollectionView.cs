using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class GamecollectionView
    {
        public int CollectionId { get; set; }
        public string Name { get; set; }
        public List<Game> Games { get; set; }

        public List<GameSubCollection> SubCollections { get; set; }

    }
}
