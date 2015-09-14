using QuickGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickGames.Services
{
    public class SequencedGridService : ISequencedGridService 
    {
        public GameGrid Create(int rows, int columns){
            GameGrid gameGrid = new GameGrid(rows, columns);

			var sequence = Enumerable.Range(1, gameGrid.NumberOfCells).ToArray();

			gameGrid.PopulateCellValues(sequence);
			gameGrid.RandomiseCells();
            
			return gameGrid;
        }
    }
}
