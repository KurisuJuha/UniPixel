using Unixel.Unity;
using Unixel.Core;
using Unixel.Core.Input;
using Unixel.Core.Vector;
using Unixel.Core.Physics;

public class Sample
{
    public UnixelCore Core;
    public UnixelInput Input;

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

    Vector2 A_Position;
    Vector2 B_Position;
    Image a_image;
    Image b_image;
    Box a_box;
    Box b_box;
    
    public void Start()
    {
        a_image = UnixelUnity.LoadImage("test");
        b_image = UnixelUnity.LoadImage("test3");

        A_Position = new Vector2(30,30);
        B_Position = new Vector2(0, 0);
        a_box.Size = new Vector2(6, 7);
        b_box.Size = new Vector2(6, 7);
        a_box.Pivot = new Vector2(1, 0);
        b_box.Pivot = new Vector2(1, 0);
    }

    public void Update()
    {
        Core.Display.Clear();
        if (Input.A)
        {
            A_Position += new Vector2(Input.Horizontal, Input.Vertical);
        }
        else
        {
            B_Position += new Vector2(Input.Horizontal, Input.Vertical);
        }

        Core.Display.SetImage(new Vector2Int((int)A_Position.x, (int)A_Position.y), a_image);
        Core.Display.SetImage(new Vector2Int((int)B_Position.x, (int)B_Position.y), b_image);

        a_box.Position = A_Position;
        b_box.Position = B_Position;

        if (a_box.Detect(b_box)) UnityEngine.Debug.Log("Detect!!!!!!!");
    }
}
