namespace maze_game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Maze Game!");

            Maze maze = new Maze(40, 20);

            while (true)
            {
                maze.DrawMaze();
                maze.MovePlayer();
            }
        }
    }
}
