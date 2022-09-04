using System.Drawing;
using System.Collections;
using System.Collections.Generic;

namespace Unixel.Core
{
    public class Image
    {
        public Color[,] image;
        public Vector2Int size;

        // シェーダー
        public delegate Color FragmentShader(Vector2Int Pos, Vector2Int Size, Color[,] image);
        public FragmentShader shader;

        public Image(Vector2Int size)
        {
            image = new Color[size.x, size.y];
            this.size = size;
            shader = (Vector2Int Pos, Vector2Int Size, Color[,] image) =>
            {
                return image[Pos.x, Pos.y];
            };
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
                    SetPixelLow(new Vector2Int(x, y), color);
//                    image[x, y] = color;
                }
            }
        }

        public void Clear() => Clear(Color.White);

        public void SetImage(Vector2Int pos, Image image)
        {
            Vector2Int size = image.size;

            for (int y = 0; y < size.y; y++)
            {
                for (int x = 0; x < size.x; x++)
                {
                    Color c = image.shader(new Vector2Int(x, y), size, image.image);
                    if (c.A != 0) SetPixel(new Vector2Int(x, y) + pos, c);
                }
            }
        }
    }
}
