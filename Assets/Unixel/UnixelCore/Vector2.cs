using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public struct Vector2
{
    public float x;
    public float y;

    public Vector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    public static Vector2 operator+ (Vector2 z, Vector2 w)
    {
        return new Vector2(z.x + w.x, z.y + w.y);
    }

    public static Vector2 operator- (Vector2 z, Vector2 w)
    {
        return new Vector2(z.x - w.x, z.y - w.y);
    }
}
