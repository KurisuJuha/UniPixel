using System;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace KYapp.Unixel
{
    public sealed class Unixel : MonoBehaviour
    {
        public static int[,] Panel { get; private set; } = new int[128, 128];

        public static readonly Color[] Pallet = new[]
        {
            new Color(0, 0, 0),
            new Color(29, 43, 83),
            new Color(126, 37, 83),
            new Color(0, 135, 81),
            new Color(171, 82, 54),
            new Color(95, 87, 79),
            new Color(194, 195, 199),
            new Color(255, 241, 232),
            new Color(255, 0, 77),
            new Color(255, 163, 0),
            new Color(255, 236, 39),
            new Color(0, 228, 54),
            new Color(41, 173, 255),
            new Color(131, 118, 156),
            new Color(255, 119, 168),
            new Color(255, 204, 170)
        };

        public Image Image;

        public Texture2D Texture2D;

        public static Action Starts;
        public static Action Updates;


        #region System

        private void Start()
        {
            Texture2D = new Texture2D(128, 128);
            foreach (var instance in CreateInterfaceInstances<Uni>())
            {
                instance?.Init();
            }


            if (Starts != null)
            {
                Starts();
            }

            Rendering();
            StartCoroutine(MainLoop());

            static Type[] GetInterfaces<T>()
            {
                return Assembly.GetExecutingAssembly().GetTypes().Where(c => c.GetInterfaces().Any(t => t == typeof(T)))
                    .ToArray();
            }

            static T[] CreateInterfaceInstances<T>() where T : class
            {
                return GetInterfaces<T>().Select(c => Activator.CreateInstance(c) as T).ToArray();
            }
        }

        public static Color GetColor(int color)
        {
            if (Pallet.Length > color)
            {
                return Pallet[color];
            }

            return Color.black;
        }

        public void Rendering()
        {
            // uiのサイズ変更
            int imageSize = Mathf.Min(Screen.width, Screen.height);
            Image.rectTransform.sizeDelta = new Vector3(imageSize, imageSize);

            // Imageにテクスチャを反映
            UpdateTexture();
            Sprite sprite = Sprite.Create(Texture2D, new Rect(0, 0, Texture2D.width, Texture2D.height),
                new Vector2(0.5f, 0.5f));
            Image.sprite = sprite;
        }

        public void UpdateTexture()
        {
            for (int y = 0; y < Panel.GetLength(1); y++)
            {
                for (int x = 0; x < Panel.GetLength(0); x++)
                {
                    int c = Panel[x, y];

                    Texture2D.SetPixel(x, y, GetColor(c));
                }
            }

            Texture2D.filterMode = FilterMode.Point;
            Texture2D.Apply();
        }

        public IEnumerator MainLoop()
        {
            while (true)
            {
                yield return new WaitForSeconds(1 / 30f);
                if (Updates != null)
                {
                    Updates();
                }

                Rendering();
            }
        }

        #endregion

        #region 開発者用の関数

        public static void SetPixel(int x, int y, int color)
        {
            if (Panel.GetLength(0) > x && Panel.GetLength(1) > y && 0 <= x && 0 <= y)
            {
                Panel[x, y] = color;
            }
        }

        public static void Clear(int color)
        {
            for (int y = 0; y < Panel.GetLength(1); y++)
            {
                for (int x = 0; x < Panel.GetLength(0); x++)
                {
                    Panel[x, y] = color;
                }
            }
        }

        public static void Clear()
        {
            Clear(0);
        }

        #endregion
    }

    public interface Uni
    {
        public void Init()
        {
            Unixel.Starts += Start;
            Unixel.Updates += Update;

        }

        public void Start();
        public void Update();
    }
}