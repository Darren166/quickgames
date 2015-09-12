using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class SequencedGridService : ISequencedGridService 
    {
        public GameGrid Create(){
            GameGrid gameGrid = new GameGrid();
            for (int id = 1; id < 10; id++)
            {
                gameGrid.Cells.Add(new Cell { Id = id });
            }
            return gameGrid;
        }
    }
}
