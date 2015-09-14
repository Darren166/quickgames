using QuickGames.Services;
using QuickGames.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuickGames.Controllers
{
    public class GridSequenceGameController : ApiController
    {
        private ISequencedGridService sequencedGridService;

        public GridSequenceGameController(ISequencedGridService sequencedGridService)
        {
            this.sequencedGridService = sequencedGridService;
        }

        public GameGrid GetNewGrid(int rows, int columns)
        {
            var gameGrid = sequencedGridService.Create(rows, columns);
            return gameGrid;

        }
    }
}
