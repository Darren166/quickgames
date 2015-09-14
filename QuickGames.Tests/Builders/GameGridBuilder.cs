using QuickGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickGames.Tests.Builders
{
    class GameGridBuilder
    {
        private GameGrid gameGrid;
        public GameGridBuilder()
        {
            this.gameGrid = new GameGrid(0,0);
        }

        public static implicit operator GameGrid(GameGridBuilder builder)
        {
            return builder.gameGrid;
        }

        public GameGridBuilder WithCell(Cell cell)
        {
            this.gameGrid.Cells.Add(cell);
            return this;
        }

    }

    class CellBuilder
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
