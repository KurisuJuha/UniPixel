using System.Collections;
using UnityEngine;
using Unixel.Core;

namespace Unixel.Unity
{
    public class UnixelUnity : MonoBehaviour
    {
        public Mesh mesh;
        public Material material;
        public UnixelCore core;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        public static void Init()
        {
            GameObject gameObject = Instantiate((GameObject)Resources.Load("Unixel"));
            gameObject.name = "Unixel";
            DontDestroyOnLoad(gameObject);
        }

        public void Awake()
        {
            core = new UnixelCore();
        }

        public void Start()
        {
            mesh = new Mesh();
            StartCoroutine(MainLoop());
        }

        public void Update()
        {
            //            float x = core.Size.x > core.Size.y ? 1 : core.Size.x / (float)core.Size.y;
            //            float y = core.Size.x > core.Size.y ? core.Size.y / (float)core.Size.x : 1;

            float x = 1;
            float y = core.Size.y / (float)core.Size.x;

            float height = y;
            float width = x;

            float a1 = x / y;
            float a2 = Camera.main.aspect;

            Debug.Log(y);

            if (a1 > a2)
            {
                // width
                Debug.Log("a");
                width *= Camera.main.orthographicSize * Camera.main.aspect;
                height *= Camera.main.orthographicSize * Camera.main.aspect;
            }
            else
            {
                // height
                Debug.Log("b");
                width *= Camera.main.orthographicSize / y;
                height *= Camera.main.orthographicSize / y;
            }



            mesh.Clear();
            mesh.SetVertices(new Vector3[]
            {
                new Vector3(-width,-height),
                new Vector3(-width,height),
                new Vector3(width,height),
                new Vector3(width,-height),
            });
            mesh.SetTriangles(new int[]
            {
                0,1,2,
                0,2,3,
            }, 0);

            Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, 0);
        }

        public IEnumerator MainLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(1 / 60f);
            }
        }
    }
}

