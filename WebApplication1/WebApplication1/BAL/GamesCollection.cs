using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DTO;
using WebApplication1.Model;
using WebApplication1.Models;

namespace WebApplication1.BAL
{
    public static class GamesCollection
    {

        public static async Task<GameCollectionDTOOut> GetGameCollections(int? gameCollectionId)
        {
            GameCollectionDTOOut gameCollectionDTOOut = new GameCollectionDTOOut();
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {
                    var gameCollectionIdParam =new SqlParameter("@gameCollectionId", SqlDbType.Int);
                    gameCollectionIdParam.Value = (object)gameCollectionId ?? DBNull.Value;

                    gameCollectionDTOOut.Gamecollections =await pOCDB_testContext.GetGameCollectionsSP
                        .FromSql("Exec dbo.[GetGameCollections] @gameCollectionId=@gameCollectionId", gameCollectionIdParam)
                        .GroupBy(g => g.GameCollectionId)
                         .Select(x => new GamecollectionView
                         {
                             CollectionId = x.Key,
                             Name = x.Select(z => z.GameCollectionName).FirstOrDefault(),
                             Games = x.GroupBy(g => g.GameId)
                                .Select(a => new Game
                                {
                                    GameId = a.Key,
                                    Name = a.Select(b => b.GameName).FirstOrDefault(),
                                }).ToList(),
                             SubCollections = x.GroupBy(g => g.SubCollectionId)
                                .Select(a => new GameSubCollection
                                {
                                    SubCollectionId = a.Key,
                                    Name = a.Select(b => b.SubCollectionName).FirstOrDefault()
                                }).ToList()

                         }).ToListAsync();
                    return gameCollectionDTOOut;
                };
            }
            catch (Exception ex)
            {
                return new GameCollectionDTOOut();
            }
        }
        public static async Task< GamesDetailsDTOOut> GetGameDetails(int? gameId)
        {
            GamesDetailsDTOOut gamesDetailsDTOOut = new GamesDetailsDTOOut();
            try
            {
                using (POCDB_testContext pOCDB_testContext = new POCDB_testContext())
                {
                    var gameIdParam = new SqlParameter("@gameId", SqlDbType.Int);
                    gameIdParam.Value = (object)gameId ?? DBNull.Value;

                    gamesDetailsDTOOut.gameDetailsView =await pOCDB_testContext.GetGamesDetaillsSP
                        .FromSql("Exec dbo.[GetGamesDetaills] @gameId=@gameId", gameIdParam)
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
                        }).ToListAsync();
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
