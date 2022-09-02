using System;
using System.Drawing;
using Unixel.Core.Input;

namespace Unixel.Core
{
    [Serializable]
    public class UnixelCore
    {
        public Vector2Int Size { get; private set; }
        public Color[,] Image { get; private set; }

        public Action Start;
        public Action Update;

        public UnixelInput Input;

        public UnixelCore(Vector2Int size)
        {
            Size = size;
            Image = new Color[Size.x, Size.y];

            Input = new UnixelInput();

            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    Image[x, y] = Color.White;
                }
            }
        }

        /// <summary>
        /// 画面に安全にピクセルを描画します。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixel(int x, int y, Color color)
        {
            if (x >= 0 && y >= 0 && x < Size.x && y < Size.y)
            {
                SetPixelLow(x, y, color);
            }
        }

        /// <summary>
        /// 画面を白色で塗りつぶします。
        /// </summary>
        public void Clear() => Clear(Color.White);
        
        /// <summary>
        /// 画面を指定した色で塗りつぶします。
        /// </summary>
        /// <param name="color"></param>
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

        #region 安全じゃないやつ

        /// <summary>
        /// 画面にピクセルを描画します。
        /// 描画できるかどうかの判定をしないため高速ですが安全ではありません。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        public void SetPixelLow(int x, int y, Color color)
        {
            Image[x, y] = color;
        }

        #endregion
    }
}