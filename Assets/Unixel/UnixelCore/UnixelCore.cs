using System;
using System.Drawing;
using Unixel.Core.Input;

namespace Unixel.Core
{
    [Serializable]
    public class UnixelCore
    {
        public Vector2Int Size { get; private set; }
        public Image Display { get; private set; }

        public Action Start;
        public Action Update;

        public UnixelInput Input;

        public UnixelCore(Vector2Int size)
        {
            Size = size;
            Display = new Image(size);

            Input = new UnixelInput();

            Display.Clear();
        }
    }
}