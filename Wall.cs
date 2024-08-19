using System;

namespace maze_game
{
    public class Wall : ImazeObject
    {
        public char Icon => '#';
        public bool IsSolid => true;
    }
}
