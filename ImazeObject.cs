using System;

namespace maze_game
{
    public interface ImazeObject
    {
        char Icon { get; }
        bool IsSolid { get; }
    }
}