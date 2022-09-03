using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Unixel.Core
{
    public class Image
    {
        public Color[,] image;
        public Vector2Int size;

        public Image(Vector2Int size)
        {
            image = new Color[size.x, size.y];
            this.size = size;
        }

        public void SetPixelLow(Vector2Int pos, Color color)
        {
            image[pos.x, pos.y] = color;
        }

        public void SetPixel(Vector2Int pos, Color color)
        {
            if (pos.x >= 0 && pos.y >= 0 && pos.x < size.x && pos.y < size.y)
            {
                SetPixelLow(pos, color);
            }
        }

        public void Clear(Color color)
        {
            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    image[x, y] = color;
                }
            }
        }

        public void Clear() => Clear(Color.White);
    }
}
