using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048_console
{
    class Map
    {
        private int[,] map;
        public int Size { get; private set; }

        public Map(int size)
        {
            Size = size;
            map = new int[size, size];
        }

        public int GetValue(int x, int y)
        {
            return IsCorrectPosition(x,y)? map[x, y]: -1;
        }

        public void SetValue(int x, int y, int value)
        {
            if (IsCorrectPosition(x, y))
                map[x, y] = value;
        }

        public bool IsCorrectPosition(int x, int y)
        {
            return x < Size && x >= 0 &&
                   y < Size && y >= 0;
        }
    }
}
