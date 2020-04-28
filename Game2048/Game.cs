using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048_console
{
    class Game
    {
        static Random rnd = new Random();
        Map map;
        bool GameIsEnd;
        public int Size { get { return map.size; } }

        public Game(int size)
        {
            map = new Map(size);
        }

        public void Start()
        {
            for (int y = 0; y < Size; y++)
                for (int x = 0; x < Size; x++)
                    map.SetValue(x, y, 0);
            AddRandomValue();
            AddRandomValue();
        }

        private void AddRandomValue()
        {
            for (int i = 0; i < 100; i++)
            {
                int x = rnd.Next(0, Size);
                int y = rnd.Next(0, Size);
                if (map.GetValue(x, y) == 0)
                {
                    map.SetValue(x, y, rnd.Next(1, 3) * 2);
                    return;
                }
            }
        }

        private void MoveTo(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)
            {
                while (map.GetValue(x + dx, y + dy) == 0)
                {
                    map.SetValue(x + dx, y + dy, map.GetValue(x, y));
                    map.SetValue(x, y, 0);
                    x += dx;
                    y += dy;
                }
            }
        }

        public void Add(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)
                if (map.GetValue(x + dx, y + dx) == map.GetValue(x, y))
                {
                    map.SetValue(x + dx, y + dy, map.GetValue(x, y) * 2);
                    while (map.GetValue(x - dx, y - dy) > 0)
                    {
                        map.SetValue(x, y, map.GetValue(x - dx, y - dy));
                        x -= dx;
                        y -= dy;                        
                    }
                    map.SetValue(x, y, 0);
                }
        }

        public void MoveUp()
        {
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    MoveTo(x, y, 0, -1);
            for (int x = 0; x < map.size; x++)
                for (int y = 1; y < map.size; y++)
                    Add(x, y, 0, -1);
            AddRandomValue();
        }

        public void MoveDown()
        {
            for (int x = 0; x < map.size; x++)           
                for (int y = map.size - 2; y >= 0; y--)
                    MoveTo(x, y, 0, 1);
            for (int x = 0; x < map.size; x++)
                for (int y = map.size - 2; y >= 0; y--)
                    Add(x, y, 0, 1);
            AddRandomValue();
        }

        public void MoveLeft()
        {
            for (int y = 0; y < map.size; y++)
                for (int x = 1; x < map.size; x++)
                    MoveTo(x, y, -1, 0);
            for (int y = 0; y < map.size; y++)
                for (int x = 1; x < map.size; x++)
                    Add(x, y, -1, 0);
            AddRandomValue();
        }

        public void MoveRight()
        {
            for (int y = 0; y < map.size; y++)
                for (int x = map.size - 2; x >= 0; x--)
                    MoveTo(x, y, +1, 0);
            for (int y = 0; y < map.size; y++)
                for (int x = map.size - 2; x >= 0; x--) 
                    Add(x, y, +1, 0);
            AddRandomValue();
        }

        public int GetValueFromMap(int x, int y)
        {
            return map.GetValue(x, y);
        }
    }
}
