﻿using System;
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
	public class GridSequenceGameControllerTests
	{
		[TestMethod]
		public void Get_New_Game_Returns_Grid_Of_Correct_Size()
		{
			// Given a request for a grid sequence game
			GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

			// When a new grid is requested that has 3 rows and 4 columns
			GameGrid gameGrid = controller.GetNewGrid(3, 4);

			// Then it has 12 cells
			Assert.AreEqual(12, gameGrid.Cells.Count);
		}

		[TestMethod]
		public void Get_New_Game_Returns_Grid_That_Has_Sequenced_Cells()
		{
			// Given a request for a grid sequence game
			GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

			// When a new grid is requested with 2 rows and 2 columns
			GameGrid gameGrid = controller.GetNewGrid(2, 2);

			// Then all sequence numbers are present and correct
			List<Cell> expectedCells = new List<Cell> { new CellBuilder().WithId(1), new CellBuilder().WithId(2), new CellBuilder().WithId(3), new CellBuilder().WithId(4) };
			gameGrid.Cells.ShouldAllBeEquivalentTo(expectedCells, options => options.Including(g => g.Id));
		}

		[TestMethod]
		public void Get_New_Game_Returns_Correctly_Sequenced_Values()
		{
			// Given a request for a grid sequence game
			GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

			// When a new grid is requested with 4 rows and 5 columns
			GameGrid gameGrid = controller.GetNewGrid(4, 5);

			// Then the ordered values correspond to the sequence
			gameGrid.Cells.OrderBy(cell => cell.Value).Should().BeInAscendingOrder(cell => cell.Id);
		}

		[TestMethod]
		public void Get_New_game_Returns_Randomised_Sequence()
		{
			// Given a request for a grid sequence game
			GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

			// When a new grid is requested with 6 rows and 3 columns
			GameGrid gameGrid = controller.GetNewGrid(6, 3);

			// Then the cell Ids are not in order
			gameGrid.Cells.Select(cell => cell.Id).Should().NotBeAscendingInOrder();
		}

		[TestMethod]
		public void Get_New_Game_Returns_Correct_Number_of_Rows_And_Columns()
		{
			// Given a request for a grid sequence game
			GridSequenceGameController controller = new GridSequenceGameController(new SequencedGridService());

			// When a new grid is requested with 3 rows and 4 columns
			GameGrid gameGrid = controller.GetNewGrid(3, 4);

			// Then we get 3 rows and 4 columns
			gameGrid.NumberOfRows.Should().Be(3);
			gameGrid.NumberOfColumns.Should().Be(4);
		}

	}
}
