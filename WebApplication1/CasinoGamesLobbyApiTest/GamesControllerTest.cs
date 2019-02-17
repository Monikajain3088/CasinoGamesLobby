using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebApplication1.Controllers;

namespace CasinoGamesLobbyApiTest
{
    [TestClass]
    class GamesControllerTest
    {
        private readonly GamesController _gamesController;
        private GamesControllerTest()
        {
            _gamesController = new GamesController();
        }

        [TestMethod]
        private void TestGameCollections_OK()
        {
            try
            {
                var result = _gamesController.GetGameCollections(GameData.gameCollectionId.ToString());
                if(result == null){
                    Assert.IsFalse(false, "should not be null");//you can show your error messages here
                } else {
                    //here comes your datagridview databind 
                }

            }
            catch (Exception ex)
            {
                Assert.Fail();
            }
        }
    }
}
