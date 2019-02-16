using System;
using System.Collections.Generic;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public static class GamesCollection
    {

        public static object GetGameCollections(string  gameCollectionId)
        {
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {
                    var res = pOCDB_testContext.Games
                            .Join(pOCDB_testContext.SubCollections, Game => Game.RefSubCollectionId, SubCollection => SubCollection.SubCollectionId, (Game, SubCollection) => new { Game = Game, SubCollection = SubCollection })
                            .Join(pOCDB_testContext.GameCollections, SubCollection => SubCollection.SubCollection.RefGameCollectionId, GameCollection => GameCollection.CollectionId, (SubCollection, GameCollection) => new { SubCollection = SubCollection, GameCollection = GameCollection })
                            .Where(con=>(!string.IsNullOrEmpty(gameCollectionId )? con.GameCollection.CollectionId ==Convert.ToInt32(gameCollectionId): true))
                            .GroupBy(g => g.GameCollection.CollectionId)
                            .Select(x => new
                            {
                                GamecollectionId = x.Key,
                                GameCollectionName = x.Select(z => z.GameCollection.Name).FirstOrDefault(),
                                GameList = x.GroupBy(g => g.SubCollection.Game.GameId)
                                .Select(fg => new
                                {
                                    GameId = fg.Key,
                                    GameName = fg.Select(dc => dc.SubCollection.Game.Name).FirstOrDefault(),
                                }).ToList(),
                                SubCollection = x.GroupBy(g => g.SubCollection.SubCollection.SubCollectionId)
                                .Select(tg => new
                                {
                                    SubCOllectionId = tg.Key,
                                    SubColleectionName = tg.Select(df => df.SubCollection.SubCollection.Name).FirstOrDefault()
                                }).ToList()

                            }).ToList();
                       
                    return res;
                };
            }
            catch (Exception ex)
            {
                return new object();
            }
        }
        public static  object GetGameDetails(string gameId)
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
            catch(Exception)
            {
                return null;
            }
        }
    }
}
