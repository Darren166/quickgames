using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGames;
using QuickGames.Controllers;
using FluentAssertions;
using QuickGames.Tests.Builders;
using Services.Models;
using Services;

namespace QuickGames.Tests.Controllers
{
    [TestClass]
    public class GridSequenceGameControllerTest
    {
        [TestMethod]
        public void Get_New_Game_Returns_Grid_Of_Correct_Size()
        {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

            // When a new grid is requested
            GameGrid gameGrid = controller.GetNewGrid();

            // Then it has 9 cells
            Assert.AreEqual(9,gameGrid.Cells.Count);
        }

        [TestMethod]
        public void Get_New_Game_Returns_Grid_That_Has_Fully_Sequenced_Cells()
        {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

            // When a new grid is requested
            GameGrid gameGrid = controller.GetNewGrid();

            // Then all sequence numbers are present and correct
            GameGrid expectedGrid = new GameGridBuilder()
                .WithCell(new CellBuilder().WithId(1))
                .WithCell(new CellBuilder().WithId(2))
                .WithCell(new CellBuilder().WithId(3))
                .WithCell(new CellBuilder().WithId(4))
                .WithCell(new CellBuilder().WithId(5))
                .WithCell(new CellBuilder().WithId(6))
                .WithCell(new CellBuilder().WithId(7))
                .WithCell(new CellBuilder().WithId(8))
                .WithCell(new CellBuilder().WithId(9));
            gameGrid.Cells.ShouldBeEquivalentTo(expectedGrid.Cells);
        }
    }
}
