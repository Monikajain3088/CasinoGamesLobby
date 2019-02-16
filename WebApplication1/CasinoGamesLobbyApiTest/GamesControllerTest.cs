using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
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
            var result = _gamesController.GetGameCollections(GameData.gameCollectionId.ToString());
           // Assert.IsFalse(, "1 should not be prime");

        }
    }
}
