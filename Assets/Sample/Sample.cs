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
    public Vector2 Position;
    Image image;

    public void Start()
    {
        image = UnixelUnity.LoadImage("test");
        Position = new Vector2(10,10);
    }

    public void Update()
    {
        Core.Display.Clear();
        Position += new Vector2(Input.Horizontal, Input.Vertical);

        Core.Display.SetImage(new Vector2Int((int)Position.x, (int)Position.y), image);
//        Core.Display.SetPixel(new Vector2Int((int)Position.x, (int)Position.y), image.image[4, 4]);
//        Core.Display.SetPixel(new Vector2Int((int)Position.x, (int)Position.y), Color.Black);
    }
}
