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
                    gameCollectionDTOOut.Gamecollections = pOCDB_testContext.GetGameCollectionsSP
                        .FromSql("Exec dbo.[GetGameCollections] @gameCollectionId={0}", Convert.ToInt32(gameCollectionId))
                        .GroupBy(g => g.GameCollectionId)
                         .Select(x => new GamecollectionView
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
        public static GamesDetailsDTOOut GetGameDetails(string gameId)
        {
            GamesDetailsDTOOut gamesDetailsDTOOut = new GamesDetailsDTOOut();
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {

                    gamesDetailsDTOOut.gameDetailsView = pOCDB_testContext.GetGamesDetaillsSP
                        .FromSql("Exec dbo.[GetGamesDetaills] @gameId={0}", Convert.ToInt32(gameId))
                        .GroupBy(g => g.GameId)
                        .Select(x => new GameDetailsView
                        {
                            Name = x.Select(g => g.Name).FirstOrDefault(),
                            GameId = x.Key,
                            Thumbnail = x.Select(g => g.Thumbnail).FirstOrDefault(),
                            CategoryName = x.Select(g => g.CategoryName).FirstOrDefault(),
                            DeviceName = x.Select(g => g.DeviceName).FirstOrDefault(),
                            GameCollections = x.Select(gc => new Gamecollection
                            {
                                CollectionId = gc.GameCollectionId,
                                Name = gc.GameCollectionName
                            }).ToList()
                        }).ToList();
                    return gamesDetailsDTOOut;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
