using System;

namespace maze_game
{
    public class Player : ImazeObject
    {
        public char Icon => '@';
        public bool IsSolid => true;

        public int X { get; set; }
        public int Y { get; set; }
    }
}
