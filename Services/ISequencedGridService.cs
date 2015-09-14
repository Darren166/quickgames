using System;
namespace QuickGames.Services
{
    public interface ISequencedGridService
    {
        QuickGames.Services.Models.GameGrid Create(int rows, int columns);
    }
}
