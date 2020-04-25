using System;
using System.Collections.Generic;
using System.Text;

namespace Game2048_console
{
    class Map
    {
        int[,] map;
        int size;

        public Map(int size)
        {
            this.size = size;
            map = new int[size, size];
        }
    }
}
