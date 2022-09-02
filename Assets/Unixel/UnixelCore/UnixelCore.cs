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
        /// ��ʂɈ��S�Ƀs�N�Z����`�悵�܂��B
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
        /// ��ʂ𔒐F�œh��Ԃ��܂��B
        /// </summary>
        public void Clear() => Clear(Color.White);
        
        /// <summary>
        /// ��ʂ��w�肵���F�œh��Ԃ��܂��B
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

        #region ���S����Ȃ����

        /// <summary>
        /// ��ʂɃs�N�Z����`�悵�܂��B
        /// �`��ł��邩�ǂ����̔�������Ȃ����ߍ����ł������S�ł͂���܂���B
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