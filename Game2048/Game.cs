using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048_console
{
    class Game
    {
        public bool gameIsEnd { get; private set; }
        public int Size { get { return map.Size; } }

        private bool wasMoveTo = false;
        private Random rnd = new Random();
        private Map map;  

        public Game(int size)
        {
            map = new Map(size);
        }

        public void Start()
        {
            gameIsEnd = false;
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    map.SetValue(x, y, 0);
            AddRandomValue();
            AddRandomValue();
        }

        void AddRandomValue()
        {
            if (gameIsEnd) return;
            for (int j = 0; j < 20; j++)
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

        void MoveTo(int x, int y, int dx, int dy)
        {
            if (map.GetValue(x, y) > 0)           
                while (map.GetValue(x + dx, y + dy) == 0)
                {
                    map.SetValue(x + dx, y + dy, map.GetValue(x, y));
                    map.SetValue(x, y, 0);
                    x += dx;
                    y += dy;
                    wasMoveTo = true;
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
                    wasMoveTo = true;
                    map.SetValue(x, y, 0);
                }
        }

        public void MoveUp()
        {
            wasMoveTo = false;
            for (int x = 0; x < Size; x++)
            {
                for (int y = 1; y < Size; y++)
                    MoveTo(x, y, 0, -1);
                for (int y = 1; y < Size; y++)
                     Add(x, y, 0, -1);
            }
            if (wasMoveTo)
                AddRandomValue();
        }

        public void MoveDown()
        {
            wasMoveTo = false;
            for (int x = 0; x < Size; x++)
            {
                for (int y = Size - 2; y >= 0; y--)
                    MoveTo(x, y, 0, 1);
                for (int y = Size - 2; y >= 0; y--)
                    Add(x, y, 0, +1);
            }
            if (wasMoveTo)
                AddRandomValue();
        }

        public void MoveLeft()
        {
            wasMoveTo = false;
            for (int y = 0; y < Size; y++)
            {
                for (int x = 1; x < Size; x++)
                    MoveTo(x, y, -1, 0);
                for (int x = 1; x < Size; x++)
                    Add(x, y, -1, 0);
            }
            if (wasMoveTo)
                AddRandomValue();
        }

        public void MoveRight()
        {
            wasMoveTo = false;
            for (int y = 0; y < Size; y++)
            {
                for (int x = Size - 2; x >= 0; x--)
                    MoveTo(x, y, +1, 0);
                for (int x = Size - 2; x >= 0; x--)
                    Add(x, y, +1, 0);
            }
            if (wasMoveTo)
                AddRandomValue();
        }

        public int GetValueFromMap(int x, int y)
        {
            return map.GetValue(x, y);
        }

        public bool GameIsEnd()
        {
            if (gameIsEnd)
                return gameIsEnd;
            for (int x = 0; x < Size; x++)
                for (int y = 0; y < Size; y++)
                    if (map.GetValue(x, y) == 0 ||
                        map.GetValue(x, y) == map.GetValue(x + 1, y) ||
                        map.GetValue(x, y) == map.GetValue(x, y + 1))
                        return false;
            gameIsEnd = true;
            return gameIsEnd;
        }
    }
}
