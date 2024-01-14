// Copyright (c) Supernova Technologies LLC
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

namespace Nova.Compat
{
    internal static class TMPUtils
    {
        public static bool WordWrapEnabled(this TextMeshPro tmp)
        {
#if TMP_UV4
            return tmp.textWrappingMode != TextWrappingModes.NoWrap;
#else
            return tmp.enableWordWrapping;
#endif
        }

        public static void DisableWordWrap(this TextMeshPro tmp)
        {
#if TMP_UV4
            tmp.textWrappingMode = TextWrappingModes.NoWrap;
#else
            tmp.enableWordWrapping = false;
#endif
        }

        public unsafe static void CopyUVs(Vector2* uv0s, Vector2* uv2s, ref TMP_MeshInfo textNodeMeshUpdate)
        {
#if TMP_UV4
            for (int i = 0; i < textNodeMeshUpdate.vertices.Length; ++i)
            {
                Vector4 src = textNodeMeshUpdate.uvs0[i];
                uv0s[i] = (Vector2)src;
                uv2s[i] = new Vector2(src.z, src.w);
            }
#else
            fixed (Vector2* src = textNodeMeshUpdate.uvs0)
            {
                UnsafeUtility.MemCpy(uv0s, src, sizeof(Vector2) * textNodeMeshUpdate.vertices.Length);
            }

            fixed (Vector2* src = textNodeMeshUpdate.uvs2)
            {
                UnsafeUtility.MemCpy(uv2s, src, sizeof(Vector2) * textNodeMeshUpdate.vertices.Length);
            }
#endif
        }
    }
}

