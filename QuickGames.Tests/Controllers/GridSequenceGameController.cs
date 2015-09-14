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
using QuickGames.Services.Models;
using QuickGames.Services;

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

            // When a new grid is requested that has 3 rows and 4 columns
            GameGrid gameGrid = controller.GetNewGrid(3,4);

            // Then it has 12 cells
            Assert.AreEqual(12,gameGrid.Cells.Count);
        }

        [TestMethod]
        public void Get_New_Game_Returns_Grid_That_Has_Sequenced_Cells()
        {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

            // When a new grid is requested with 3 rows and 3 columns
            GameGrid gameGrid = controller.GetNewGrid(3,3);

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
            gameGrid.Cells.ShouldAllBeEquivalentTo(expectedGrid.Cells,options=>options.Including(g=>g.Id));
       }

        [TestMethod]
        public void Get_New_Game_Returns_Correctly_Sequenced_Values() {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

            // When a new grid is requested with 4 rows and 5 columns
            GameGrid gameGrid = controller.GetNewGrid(4,5);

            // Then the ordered values correspond to the sequence
            gameGrid.Cells.OrderBy(cell=>cell.Value).Should().BeInAscendingOrder(cell=>cell.Id);
        }

        [TestMethod]
        public void Get_New_game_Returns_Randomised_Sequence() {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

            // When a new grid is requested with 6 rows and 3 columns
            GameGrid gameGrid = controller.GetNewGrid(6,3);

            // Then the cell Ids are not in order
            gameGrid.Cells.Select(cell=>cell.Id).Should().NotBeAscendingInOrder();
        }

        [TestMethod]
        public void Get_New_Game_Returns_Correct_Number_of_Rows_And_Columns() {
            // Given a request for a grid sequence game
            GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

            // When a new grid is requested with 3 rows and 4 columns
            GameGrid gameGrid = controller.GetNewGrid(3,4);

            // Then we get 3 rows and 4 columns
            gameGrid.NumberOfRows.Should().Be(3);
            gameGrid.NumberOfColumns.Should().Be(4);
        }

    }
}
