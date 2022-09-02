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
            float height = core.Size.y / (float)core.Size.x;
            float width = 1;

            float m = width / height > Camera.main.aspect ? Camera.main.orthographicSize * Camera.main.aspect : Camera.main.orthographicSize / height;

            width *= m;
            height *= m;



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

