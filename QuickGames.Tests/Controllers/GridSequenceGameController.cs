using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGames;
using QuickGames.Controllers;
using QuickGames.Models;

namespace QuickGames.Tests.Controllers
{
    [TestClass]
    public class GridSequenceGameControllerTest
    {
        [TestMethod]
        public void Get_New_Game_Returns_Grid_Of_Correct_Size()
        {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController();

            // When a new grid is requested
            GameGrid gameGrid = controller.GetNewGrid();

            // Then it has 9 cells
            Assert.AreEqual(gameGrid.Cells.Length,9);
            
        }
    }
}
