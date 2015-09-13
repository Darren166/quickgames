using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;

namespace QuickGames.Services.Models
{
    public class GameGrid
    {
        public GameGrid()
        {
            Cells = new List<Cell>();
        }

        public IList<Cell> Cells { get; set; }
    }

    public class Cell
    {
        public int Id { get; set; }
        public int Value { get; set; }
    }
}