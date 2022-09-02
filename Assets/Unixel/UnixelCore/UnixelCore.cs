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
        public void SetPixel(Vector2Int pos, Color color)
        {
            if (pos.x >= 0 && pos.y >= 0 && pos.x < Size.x && pos.y < Size.y)
            {
                SetPixelLow(pos, color);
            }
        }

        /// <summary>
        /// ��ʂ𔒐F�œh��Ԃ��܂��B
        /// </summary>
        public void Clear() => Clear(Color.White);
        
        /// <summary>
        /// ��ʂ��w�肵���F�œh��Ԃ��܂��B
        /// </summary>
        public void Clear(Color color)
        {
            for (int y = 0; y < Size.y; y++)
            {
                for (int x = 0; x < Size.x; x++)
                {
                    SetPixelLow(new Vector2Int(x, y), color);
                }
            }
        }

        #region ���S����Ȃ����

        /// <summary>
        /// ��ʂɃs�N�Z����`�悵�܂��B
        /// �`��ł��邩�ǂ����̔�������Ȃ����ߍ����ł������S�ł͂���܂���B
        /// </summary>
        public void SetPixelLow(Vector2Int pos, Color color)
        {
            Image[pos.x, pos.y] = color;
        }

        #endregion
    }
}