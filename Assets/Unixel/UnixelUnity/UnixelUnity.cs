using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unixel.Core;

namespace Unixel.Unity
{
    public class UnixelUnity : MonoBehaviour
    {
        public Mesh mesh;
        public Material material;
        public Texture2D texture;
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

        }

        public void Start()
        {
            core = new UnixelCore();
            mesh = new Mesh();
            texture = new Texture2D(core.Size.x, core.Size.y);
            texture.filterMode = FilterMode.Point;
            material.color = Color.white;
            material.mainTexture = texture;
            StartCoroutine(MainLoop());
        }

        public void Update()
        {
            MeshGenerate();
            TextureGenerate();
            Graphics.DrawMesh(mesh, Vector3.zero, Quaternion.identity, material, 0);
        }

        public IEnumerator MainLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(1 / 60f);
            }
        }

        public void MeshGenerate()
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
            mesh.SetUVs(0, new List<UnityEngine.Vector2>()
            {
                new UnityEngine.Vector2(0,0),
                new UnityEngine.Vector2(0,1),
                new UnityEngine.Vector2(1,1),
                new UnityEngine.Vector2(1,0),
            });
        }

        public void TextureGenerate()
        {
            var pixelData = texture.GetPixelData<Color32>(0);
            for (int y = 0; y < core.Size.y; y++)
            {
                for (int x = 0; x < core.Size.x; x++)
                {
                    var c = core.Image[x, y];
                    pixelData[y * core.Size.x + x] = new Color(c.R, c.G, c.B);
                }
            }
            texture.Apply();
        }
    }
}
