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

        public Action Start;
        public Action Update;

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
        }

        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && y >= 0 && x < Size.x && y < Size.y)
            {
                SetPixelLow(x, y, color);
            }
        }

        public void Clear() => Clear(Color.White);

        public void Clear(Color color)
        {
            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    SetPixelLow(x, y, color);
                }
            }
        }

        public void SetPixelLow(int x, int y, Color color)
        {
            Image[x, y] = color;
        }
    }
}