using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuickGames.Models
{
    public class GameGrid
    {
        public GameGrid()
        {
            Cells = new int[9];
        }
        public int[] Cells { get; set; }
    }
}