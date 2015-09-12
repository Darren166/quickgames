using QuickGames.Models;
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
        public GameGrid GetNewGrid()
        {
            return new GameGrid();
        }
    }
}
