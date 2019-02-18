using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Controllers;
using WebApplication1.DTO;

namespace CasinoGamesLobbyApiTest
{
    [TestClass]
   public class GamesControllerTest
    {
        public readonly GamesController _gamesController;
        public GamesControllerTest()
        {
            _gamesController = new GamesController();
        }
        /// <summary>
        /// Test Game collection get fulll list of game collection.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGameCollectionsByNullParam_OK()
        {
            try
            {
                var result =await _gamesController.GetGameCollections(null);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GameCollectionDTOOut));
                GameCollectionDTOOut gameCollectionDTOOut = (GameCollectionDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gameCollectionDTOOut.Gamecollections.Count==0);
               
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Test Game collection by passing game collection Id
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGameCollectionsByGameCollectionId_OK()
        {
            try
            {
                var result = await _gamesController.GetGameCollections(1);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GameCollectionDTOOut));
                GameCollectionDTOOut gameCollectionDTOOut = (GameCollectionDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gameCollectionDTOOut.Gamecollections.Count == 0);
                Assert.AreEqual(gameCollectionDTOOut.Gamecollections.Count, 1);                
               Assert.AreEqual(gameCollectionDTOOut.Gamecollections.Select(x => x.Games).ToList()[0].Count, 7);  
                
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Test Game collection by passing game collection Id 2
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGameCollectionsByAnotherGameCollectionId_OK()
        {
            try
            {
                var result = await _gamesController.GetGameCollections(2);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GameCollectionDTOOut));
                GameCollectionDTOOut gameCollectionDTOOut = (GameCollectionDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gameCollectionDTOOut.Gamecollections.Count == 0);               
                Assert.AreEqual(gameCollectionDTOOut.Gamecollections.Select(x => x.Games).ToList()[0].Count, 8);

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Test Game Details by passing game Id NUll
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGameDetaillsByPassingNullParam()
        {
            try
            {
                var result = await _gamesController.GetGameDetails(null);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GamesDetailsDTOOut));
                GamesDetailsDTOOut gamesDetailsDTOOut = (GamesDetailsDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gamesDetailsDTOOut.gameDetailsView.Count==0);
                Assert.AreEqual(gamesDetailsDTOOut.gameDetailsView.Count ,15 );
                Assert.AreEqual(gamesDetailsDTOOut.gameDetailsView.ToList()[1].GameCollections.Count, 2);
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Test Game Details by passing game Id 8
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGameDetaillsByPassingGameId()
        {
            try
            {
                var result = await _gamesController.GetGameDetails(8);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GamesDetailsDTOOut));
                GamesDetailsDTOOut gamesDetailsDTOOut = (GamesDetailsDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gamesDetailsDTOOut.gameDetailsView.Count == 0);
                Assert.AreEqual(gamesDetailsDTOOut.gameDetailsView.Count, 1);
                Assert.AreEqual(gamesDetailsDTOOut.gameDetailsView.ToList()[0].Name, "Mystery Joker");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
        /// <summary>
        /// Test Game Details by passing game Id 8
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task TestGameDetaillsByAnotherPassingGameId()
        {
            try
            {
                var result = await _gamesController.GetGameDetails(8);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GamesDetailsDTOOut));
                GamesDetailsDTOOut gamesDetailsDTOOut = (GamesDetailsDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gamesDetailsDTOOut.gameDetailsView.Count == 0);
                Assert.AreEqual(gamesDetailsDTOOut.gameDetailsView.Count, 1);
                Assert.AreEqual(gamesDetailsDTOOut.gameDetailsView.ToList()[0].DeviceName, "Mobile");
            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
