// Copyright (c) Supernova Technologies LLC
using UnityEditor;
using UnityEngine;

namespace Nova.Compat
{
    internal static class HandleCompat
    {
        public static Vector3 FreeMoveHandle(Vector3 position, float size, Vector3 snap, Handles.CapFunction capFunction)
        {
#if UNITY_2022_1_OR_NEWER
            return Handles.FreeMoveHandle(position, size, snap, capFunction);
#else
            return Handles.FreeMoveHandle(position, Quaternion.identity, size, snap, capFunction);
#endif
        }
    }
}
