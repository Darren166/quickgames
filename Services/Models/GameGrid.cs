using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace QuickGames.Services.Models
{
	public class GameGrid
	{
		public GameGrid(int rows, int columns)
		{
			this.NumberOfRows = rows;
			this.NumberOfColumns = columns;
			Cells = CreateDefaultCells(rows, columns);
		}

		public IList<Cell> Cells { get; set; }
		public int NumberOfRows { get; set; }
		public int NumberOfColumns { get; set; }
		public int NumberOfCells { get { return NumberOfRows * NumberOfColumns; } }

		public void PopulateCellValues(int[] orderedValues)
		{
			foreach (var cell in this.Cells)
			{
				cell.Value = orderedValues[cell.Id - 1];
			}
		}

		public void RandomiseCells()
		{
			this.Cells = this.Cells.OrderBy(guid => Guid.NewGuid()).ToList();
		}

		private List<Cell> CreateDefaultCells(int rows, int columns)
		{
			var cells = new List<Cell>();
			for (int cellNumber = 1; cellNumber < 1 + (rows * columns); cellNumber++)
			{
				cells.Add(new Cell { Id = cellNumber });
			}
			return cells;
		}
	}

	public class Cell
	{
		public int Id { get; set; }
		public int Value { get; set; }
	}
}