using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using Unixel.Unity;
using Unixel.Core;

public class Sample
{
    [UnityEngine.RuntimeInitializeOnLoadMethod(UnityEngine.RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Init()
    {
        var s = new Sample();

        s.core = UnixelUnity.core;
        UnixelUnity.core.Start += s.Start;
        UnixelUnity.core.Update += s.Update;
    }

    public UnixelCore core;

    public void Start()
    {
        core.SetPixel(64, 32, Color.Black);
    }

    public void Update()
    {
        core.Clear();
    }
}
