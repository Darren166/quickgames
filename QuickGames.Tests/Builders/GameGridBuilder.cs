﻿using QuickGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickGames.Tests.Builders
{
	public class GameGridBuilder
	{
		private GameGrid gameGrid;
		public GameGridBuilder(int rows, int columns)
		{
			this.gameGrid = new GameGrid(rows, columns);
		}

		public static implicit operator GameGrid(GameGridBuilder builder)
		{
			return builder.gameGrid;
		}
	}

	public class CellBuilder
	{
		private Cell cell;
		public CellBuilder()
		{
			this.cell = new Cell();
		}

		public static implicit operator Cell(CellBuilder builder)
		{
			return builder.cell;
		}

		public CellBuilder WithId(int id)
		{
			cell.Id = id;
			return this;
		}
	}
}
