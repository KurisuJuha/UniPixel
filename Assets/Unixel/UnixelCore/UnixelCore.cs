using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Unixel.Core
{
    [Serializable]
    public class UnixelCore
    {
        public Vector2Int Size { get; private set; }
        public Color[,] Image { get; private set; }

        public UnixelCore()
        {
            Size = new Vector2Int(128, 64);
            Image = new Color[Size.x, Size.y];

            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    Image[x, y] = Color.White;
                }
            }

            Image[64, 32] = Color.Black;
        }
    }
}