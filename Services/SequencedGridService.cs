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
        public GameGrid Create(){
            GameGrid gameGrid = new GameGrid();
            var sequence = Enumerable.Range(1, 9).ToArray();

            var cellIndex = 0;
            foreach (var item in sequence)
            {
                cellIndex++;
                gameGrid.Cells.Add(new Cell { Id = cellIndex, Value = item });
            }
            return gameGrid;
        }
    }
}
