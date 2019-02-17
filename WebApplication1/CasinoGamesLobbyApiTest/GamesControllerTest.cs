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
        [TestMethod]
        public async Task TestGameCollectionsByGameCollectionId_OK()
        {
            try
            {
                var result = await _gamesController.GetGameCollections(3);
                Assert.IsNotNull(result);
                Assert.IsInstanceOfType(((ObjectResult)result).Value, typeof(GameCollectionDTOOut));
                GameCollectionDTOOut gameCollectionDTOOut = (GameCollectionDTOOut)((ObjectResult)result).Value;
                Assert.IsFalse(gameCollectionDTOOut.Gamecollections.Count == 0);

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
