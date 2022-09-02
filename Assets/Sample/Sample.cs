using System.Collections;
using System.Collections.Generic;
using Unixel.Unity;
using UnityEngine;

public class Sample
{
    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    public static void Init()
    {
        var s = new Sample();

        UnixelUnity.core.Start += s.Start;
        UnixelUnity.core.Update += s.Update;
    }

    public void Start()
    {
        Debug.Log("start");
    }

    public void Update()
    {
        Debug.Log("update");
    }
}
