using Microsoft.EntityFrameworkCore;
using System;
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
                    gameCollectionDTOOut.Gamecollections = pOCDB_testContext.GetGameCollectionsSP.FromSql("Exec dbo.[GetGameCollections] @gameCollectionId={0}", Convert.ToInt32(gameCollectionId))
                        .GroupBy(g => g.GameCollectionId)
                         .Select(x => new Gamecollection
                         {
                             CollectionId = x.Key,
                             Name = x.Select(z => z.GameCollectionName).FirstOrDefault(),
                             Games = x.GroupBy(g => g.GameId)
                                .Select(fg => new Game
                                {
                                    GameId = fg.Key,
                                    Name = fg.Select(dc => dc.GameName).FirstOrDefault(),
                                }).ToList(),
                             SubCollections = x.GroupBy(g => g.SubCollectionId)
                                .Select(tg => new GameSubCollection
                                {
                                    SubCollectionId = tg.Key,
                                    Name = tg.Select(df => df.SubCollectionName).FirstOrDefault()
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
