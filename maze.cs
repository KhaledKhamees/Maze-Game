using System;

namespace maze_game
{
    public class Maze
    {
        public int Width { get; }
        public int Height { get; }
        private Player player;
        private ImazeObject[,] board;

        public Maze(int width, int height)
        {
            Width = width;
            Height = height;
            board = new ImazeObject[width, height];
            InitializeBoard();
            player = new Player() { X = 1, Y = 1 }; // Start position adjusted to avoid initial wall overlap
            board[player.X, player.Y] = player;
        }

        private void InitializeBoard()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (x == 0 || x == Width - 1 || y == 0 || y == Height - 1)
                    {
                        board[x, y] = new Wall();
                    }
                    else if (x % 3 == 0 && y % 5 == 0 ||
                             x % 5 == 0 && y % 4 == 0 ||
                             x % 7 == 0 && y % 4 == 0)
                    {
                        board[x, y] = new Wall();
                    }
                    else
                    {
                        board[x, y] = new EmptySpace();
                    }
                }
            }
        }

        public void DrawMaze()
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    Console.Write(board[x, y].Icon);
                }
                Console.WriteLine(); // Move to the next row after drawing the current row
            }
        }

        public void MovePlayer()
        {
            ConsoleKeyInfo input = Console.ReadKey();
            switch (input.Key)
            {
                case ConsoleKey.UpArrow:
                    UpdatePlayer(0, -1);
                    break;
                case ConsoleKey.DownArrow:
                    UpdatePlayer(0, 1);
                    break;
                case ConsoleKey.RightArrow:
                    UpdatePlayer(1, 0);
                    break;
                case ConsoleKey.LeftArrow:
                    UpdatePlayer(-1, 0);
                    break;
            }
        }

        private void UpdatePlayer(int dx, int dy)
        {
            int newX = player.X + dx;
            int newY = player.Y + dy;

            if (IsValidMove(newX, newY))
            {
                board[player.X, player.Y] = new EmptySpace(); // Clear old position
                player.X = newX;
                player.Y = newY;
                board[player.X, player.Y] = player; // Set new position
                DrawMaze();
            }
        }

        private bool IsValidMove(int x, int y)
        {
            return x >= 1 && x < Width - 1 && y >= 1 && y < Height - 1 && !board[x, y].IsSolid;
        }
    }
}
