using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace NovaSamples.DummyScripts
{
    [ExecuteAlways]
    public class DummyCubeAnimator : MonoBehaviour
    {
        private static readonly Color Magenta = new Color(1, 0.2f, 1);
        private static readonly Color Orange = new Color(1, 0.6f, 0);
        private static readonly Color Yellow = new Color(0.87f, 1,0.2f);
        private static readonly Color Green = new Color(0, 1, 0.33f);
        private static readonly Color Cyan = new Color(0, 1, 1);
        private static readonly Color Blue = new Color(0, 0.33f, 1);

        private static readonly float XRotation = Mathf.Atan(1 / Mathf.Sqrt(2)) * Mathf.Rad2Deg;
        private static readonly float ZRotation = 45;

        [Min(0)]
        public int Rows = 5;
        [Min(0)]
        public int Columns = 5;

        [Min(1)]
        public float DistanceFromCamera = 15;

        [Tooltip("Degrees per second")]
        public float RotateBy = 45;

        public List<Color> CubeColors = new List<Color>()
        {
            Magenta,
            Orange,
            Yellow,
            Green,
            Cyan,
            Blue
        };

        [NonSerialized]
        private List<Material> materials = new List<Material>();

        [NonSerialized]
        private List<List<Matrix4x4>> matrices = new List<List<Matrix4x4>>();

#pragma warning disable 0414 // The private field is assigned but its value is never used - logged when building
        [NonSerialized]
        private bool primitivesInitialized = false;

        [SerializeField, HideInInspector]
        private Shader shader = null;
#pragma warning restore 0414

        [SerializeField, HideInInspector]
        private Material material = null;
        private Material Material
        {
            get
            {
                EnsurePrimitives();

                return material;
            }
        }

        [SerializeField, HideInInspector]
        private Mesh mesh = null;
        private Mesh Mesh
        {
            get 
            {
                EnsurePrimitives();

                return mesh;
            }
        }

        private void Update()
        {
            EnsureMaterials();

            float yRotation = Application.IsPlaying(this) ? Time.time * RotateBy : 0;
            Quaternion rotation = Quaternion.Euler(XRotation, yRotation, ZRotation);

            Camera camera = Camera.main;

            if (camera == null)
            {
                return;
            }

            float rowHeight = 1f / Rows;
            float colWidth = 1f / Columns;

            int numDrawCalls = 0;
            for (int row = 0; row < Rows; ++row)
            {
                float viewportY = (row + 0.5f) * rowHeight;

                for (int col = 0; col < Columns; ++col)
                {
                    int cubeIndex = row * Columns + col;
                    int materialIndex = cubeIndex % materials.Count;
                    numDrawCalls = Mathf.Max(numDrawCalls, materialIndex);

                    float viewportX = (col + 0.5f) * colWidth;

                    Vector3 position = camera.ViewportToWorldPoint(new Vector3(viewportX, viewportY, DistanceFromCamera));

                    matrices[materialIndex].Add(Matrix4x4.TRS(position, rotation, Vector3.one));
                }
            }

            for (int i = 0; i <= numDrawCalls; ++i)
            {
                Graphics.DrawMeshInstanced(Mesh, 0, materials[i], matrices[i], null, UnityEngine.Rendering.ShadowCastingMode.Off, receiveShadows: false);
            }
        }

        private void OnDisable()
        {
            for (int i = 0; i < materials.Count; ++i)
            {
                Material.DestroyImmediate(materials[i]);
            }

            materials.Clear();
        }

        private void EnsureMaterials()
        {
            int materialCount = Mathf.Max(CubeColors.Count, 1);

            while (materials.Count > materialCount)
            {
                Material.DestroyImmediate(materials[materials.Count - 1]);
                materials.RemoveAt(materials.Count - 1);
                matrices.RemoveAt(matrices.Count - 1);
            }

            while (materials.Count < materialCount)
            {
                materials.Add(new Material(Material) { enableInstancing = true });
                matrices.Add(new List<Matrix4x4>());
            }

            if (CubeColors.Count == 0)
            {
                materials[0].color = Color.white;
                matrices[0].Clear();
            }
            else
            {
                for (int i = 0; i < CubeColors.Count; ++i)
                {
                    materials[i].color = CubeColors[i];
                    matrices[i].Clear();
                }
            }
        }

        private void EnsurePrimitives()
        {
#if !UNITY_EDITOR
            return;
#else
            if (primitivesInitialized && mesh != null && material != null)
            {
                return;
            }

            bool saveScene = gameObject.scene == SceneManager.GetActiveScene() && !gameObject.scene.isDirty;

            primitivesInitialized = true;

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Mesh primitiveMesh = go.GetComponent<MeshFilter>().sharedMesh;
            Material primitiveMaterial = new Material(go.GetComponent<MeshRenderer>().sharedMaterial);
            GameObject.DestroyImmediate(go);

            if (primitiveMesh == mesh && shader == primitiveMaterial.shader)
            {
                return;
            }

            UnityEditor.Undo.RecordObject(this, "Init Cubes");

            mesh = primitiveMesh;
            shader = primitiveMaterial.shader;
            material = new Material(shader);
            material.enableInstancing = true;

            if (saveScene)
            {
                UnityEditor.EditorApplication.delayCall += () =>
                {
                    if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
                    {
                        return;
                    }

                    UnityEditor.SceneManagement.EditorSceneManager.SaveScene(gameObject.scene);
                };
            }
#endif
        }
    }
}
