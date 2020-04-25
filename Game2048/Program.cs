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
                switch(Console.ReadKey(false).Key)
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

        static void Show(Game game)
        {
                /* for y
                 *      for x
                 *      setcursor
                 *      write Value
                 *      */
        }
    }
}
