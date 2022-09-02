using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using Unixel.Unity;
using Unixel.Core;
using Unixel.Core.Input;

public class Sample
{
    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Init()
    {
        var s = new Sample();

        UnixelUnity.Init(128, 128);
        s.Core = UnixelUnity.core;
        s.Input = s.Core.Input;
        UnixelUnity.core.Start += s.Start;
        UnixelUnity.core.Update += s.Update;
    }

    public UnixelCore Core;
    public UnixelInput Input;
    public Vector2Int Position;

    public void Start()
    {
        Core.SetPixel(64, 32, Color.Black);
    }

    public void Update()
    {
        Position += new Vector2Int((int)Input.Horizontal, (int)Input.Vertical);
        Core.Clear();
    }
}
