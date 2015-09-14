using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace QuickGames.Tests.Builders
{
	[TestClass]
	class GameGridBuilderTests
	{
		[TestMethod]
		public void Builder_Creates_Correct_number_of_Cells() { 
			// When I build a game grid with 3 rows and 4 columns
			GameGrid gameGrid = new GameGridBuilder(rows: 3, columns: 4);

			// Then I get a grid with 12 cells
			gameGrid.NumberOfCells.Should().Be(12);
		}
	}
}
