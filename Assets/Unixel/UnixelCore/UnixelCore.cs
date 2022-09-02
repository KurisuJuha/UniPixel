using System;
using System.Collections;
using System.Collections.Generic;

namespace Unixel.Core
{
    [Serializable]
    public class UnixelCore
    {
        public Vector2Int Size { get; private set; } = new Vector2Int(128, 32);
    }
}