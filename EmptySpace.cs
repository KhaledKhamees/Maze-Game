using System;

namespace maze_game
{
    public class EmptySpace : ImazeObject
    {
        public char Icon => ' ';
        public bool IsSolid => false;
    }
}