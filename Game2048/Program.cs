using System;

namespace Game2048_console
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            p.Start(4);
        }

        Game game;
        void Start(int size)
        {
            game = new Game(size);
            game.Start();
            while (true)
            {
                Show(game);
                switch (Console.ReadKey(false).Key)
                {
                    case ConsoleKey.UpArrow:
                        game.MoveUp();
                        break;
                    case ConsoleKey.DownArrow:
                        game.MoveDown();
                        break;
                    case ConsoleKey.LeftArrow:
                        game.MoveLeft();
                        break;
                    case ConsoleKey.RightArrow:
                        game.MoveRight();
                        break;
                    case ConsoleKey.Escape:
                        return;

                }
            }
        }

        void Show(Game game)
        {
            Console.SetWindowSize(30, 20);
            for (int y = 0; y < game.Size; y++)
                for (int x = 0; x < game.Size; x++)
                {
                    Console.SetCursorPosition(x * 5+5, y * 2+2);
                    int value = game.GetValueFromMap(x, y);
                    Console.WriteLine(value != 0 ? value.ToString()+"   " : ".    ");
                }
            Console.WriteLine();
        }  
    }
}
