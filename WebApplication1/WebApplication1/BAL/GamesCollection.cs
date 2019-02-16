using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.DTO;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public static class GamesCollection
    {

        public static GameCollectionDTOOut GetGameCollections(string gameCollectionId)
        {
            GameCollectionDTOOut gameCollectionDTOOut = new GameCollectionDTOOut();
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {
                    gameCollectionDTOOut.Gamecollections = pOCDB_testContext.Games
                             .Join(pOCDB_testContext.SubCollections, Game => Game.RefSubCollectionId, SubCollection => SubCollection.SubCollectionId, (Game, SubCollection) => new { Game = Game, SubCollection = SubCollection })
                             .Join(pOCDB_testContext.GameCollections, SubCollection => SubCollection.SubCollection.RefGameCollectionId, GameCollection => GameCollection.CollectionId, (SubCollection, GameCollection) => new { SubCollection = SubCollection, GameCollection = GameCollection })
                             .Where(con => (!string.IsNullOrEmpty(gameCollectionId) ? con.GameCollection.CollectionId == Convert.ToInt32(gameCollectionId) : true))
                             .GroupBy(g => g.GameCollection.CollectionId)
                             .Select(x => new Gamecollection
                             {
                                 CollectionId = x.Key,
                                 Name = x.Select(z => z.GameCollection.Name).FirstOrDefault(),
                                 Games = x.GroupBy(g => g.SubCollection.Game.GameId)
                                 .Select(fg => new Game
                                 {
                                     GameId = fg.Key,
                                     Name = fg.Select(dc => dc.SubCollection.Game.Name).FirstOrDefault(),
                                 }).ToList(),
                                 SubCollections = x.GroupBy(g => g.SubCollection.SubCollection.SubCollectionId)
                                 .Select(tg => new GameSubCollection
                                 {
                                     SubCollectionId = tg.Key,
                                     Name = tg.Select(df => df.SubCollection.SubCollection.Name).FirstOrDefault()
                                 }).ToList()

                             }).ToList();

                    return gameCollectionDTOOut;
                };
            }
            catch (Exception ex)
            {
                return new GameCollectionDTOOut();
            }
        }
        public static object GetGameDetails(string gameId)
        {
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {
                    var res = from gms in pOCDB_testContext.Games
                              join gmsctgry in pOCDB_testContext.GameCategory on gms.RefCategoryId equals gmsctgry.CategoryId
                              join gmsdvc in pOCDB_testContext.GamesDevice on gms.RefDeviceId equals gmsdvc.DeviceId
                              join gmscoll in pOCDB_testContext.SubCollections on gms.RefSubCollectionId equals gmscoll.SubCollectionId
                              where gms.GameId == Convert.ToInt32(gameId)
                              select new
                              {
                                  GameName = gms.Name,
                                  gms.Thumbnail,
                                  gmsctgry.CategoryName,
                                  DeviceName = gmsdvc.Name,
                                  GameCollectionName = gmscoll.Name
                              };
                    return res.ToList();
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
