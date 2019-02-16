using Microsoft.EntityFrameworkCore;
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
                    //gameCollectionDTOOut.Gamecollections =
                    //    = pOCDB_testContext.Games
                    //         .Join(pOCDB_testContext.SubCollections, Game => Game.RefSubCollectionId, SubCollection => SubCollection.SubCollectionId, (Game, SubCollection) => new { Game = Game, SubCollection = SubCollection })
                    //         .Join(pOCDB_testContext.GameCollections, SubCollection => SubCollection.SubCollection.RefGameCollectionId, GameCollection => GameCollection.CollectionId, (SubCollection, GameCollection) => new { SubCollection = SubCollection, GameCollection = GameCollection })
                    //         .Where(con => (!string.IsNullOrEmpty(gameCollectionId) ? con.GameCollection.CollectionId == Convert.ToInt32(gameCollectionId) : true))
                    //         .GroupBy(g => g.GameCollection.CollectionId)
                    //         .Select(x => new Gamecollection
                    //         {
                    //             CollectionId = x.Key,
                    //             Name = x.Select(z => z.GameCollection.Name).FirstOrDefault(),
                    //             Games = x.GroupBy(g => g.SubCollection.Game.GameId)
                    //             .Select(fg => new Game
                    //             {
                    //                 GameId = fg.Key,
                    //                 Name = fg.Select(dc => dc.SubCollection.Game.Name).FirstOrDefault(),
                    //             }).ToList(),
                    //             SubCollections = x.GroupBy(g => g.SubCollection.SubCollection.SubCollectionId)
                    //             .Select(tg => new GameSubCollection
                    //             {
                    //                 SubCollectionId = tg.Key,
                    //                 Name = tg.Select(df => df.SubCollection.SubCollection.Name).FirstOrDefault()
                    //             }).ToList()

                    //         }).ToList();

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

                    var dbResults = pOCDB_testContext.GetGamesDetaillsSP.FromSql("Exec dbo.[GetGamesDetaills] @gameId={0}", Convert.ToInt32(gameId)).ToList();
                    var Res = dbResults.Select(x => new
                    {
                        Gname = x.Name,
                        GameId = x.GameId,
                        GameTombnil = x.Thumbnail,
                        GameCategory = x.CategoryName,
                        GameCategoryId = x.CategoryId,
                        DeviceName = x.DeviceName,
                        GameCOllectionList = dbResults.GroupBy(g => g)

                    });
                    return dbResults.ToList();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
