using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KYapp.Unixel;

public class Sample : Uni
{
    public Vector2Int pos = new Vector2Int();
    
    public void Start()
    {
        
    }
    public void Update()
    {
        Unixel.Clear(6);

        if (Input.GetKey(KeyCode.A))
        {
            pos.x--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            pos.x++;
        }
        if (Input.GetKey(KeyCode.W))
        {
            pos.y++;
        }
        if (Input.GetKey(KeyCode.S))
        {
            pos.y--;
        }
        
        Unixel.SetPixel(pos.x, pos.y, 0);
    }
}