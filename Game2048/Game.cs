using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048_console
{
    class Game
    {
        public bool GameIsEnd { get; }
        public int Size { get { return map.Size; } }

        static Random rnd = new Random();
        Map map;      

        public Game(int size)
        {
            map = new Map(size);
        }

        public void Start()
        {
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    map.SetValue(x, y, 0);
            AddRandomValue();
            AddRandomValue();
        }

        void AddRandomValue()
        {
            if (GameIsEnd) return;
            for (int j = 0; j < 100; j++)
            {
                int x = rnd.Next(0, map.Size);
                int y = rnd.Next(0, map.Size);
                if (map.GetValue(x, y) == 0)
                {
                    map.SetValue(x, y, rnd.Next(1, 3) * 2);
                    return;
                }
            }
        }

        void MoveTo(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)           
                while (map.GetValue(x + dx, y + dy) == 0)
                {
                    map.SetValue(x + dx, y + dy, map.GetValue(x, y));
                    map.SetValue(x, y, 0);
                    x += dx;
                    y += dy;
                }            
        }

        void Add(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)
                if (map.GetValue(x + dx, y + dy) == map.GetValue(x, y))
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
            for (int x = 0; x < map.Size; x++)
                for (int y = 1; y < map.Size; y++)
                    MoveTo(x, y, 0, -1);
            for (int x = 0; x < map.Size; x++)
                for (int y = 1; y < map.Size; y++)
                    Add(x, y, 0, -1);
            AddRandomValue();
        }

        public void MoveDown()
        {
            for (int x = 0; x < map.Size; x++)           
                for (int y = map.Size - 2; y >= 0; y--)
                    MoveTo(x, y, 0, 1);
            for (int x = 0; x < map.Size; x++)
                for (int y = map.Size - 2; y >= 0; y--)
                    Add(x, y, 0, +1);
            AddRandomValue();
        }

        public void MoveLeft()
        {
            for (int y = 0; y < map.Size; y++)
                for (int x = 1; x < map.Size; x++)
                    MoveTo(x, y, -1, 0);
            for (int y = 0; y < map.Size; y++)
                for (int x = 1; x < map.Size; x++)
                    Add(x, y, -1, 0);
            AddRandomValue();
        }

        public void MoveRight()
        {
            for (int y = 0; y < map.Size; y++)
                for (int x = map.Size - 2; x >= 0; x--)
                    MoveTo(x, y, +1, 0);
            for (int y = 0; y < map.Size; y++)
                for (int x = map.Size - 2; x >= 0; x--) 
                    Add(x, y, +1, 0);
            AddRandomValue();
        }

        public int GetValueFromMap(int x, int y)
        {
            return map.GetValue(x, y);
        }
    }
}
