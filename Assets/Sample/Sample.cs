using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : Uni
{
    public void Start()
    {
        
    }
    public void Update()
    {
        UniPixel.Clear();
        UniPixel.SetPixel(0, 0, 6);
    }
}