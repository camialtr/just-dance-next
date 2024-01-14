// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_12;
using UnityEngine;

namespace Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6
{
    internal static class InternalType_793
    {
        public static Matrix4x4 InternalMethod_1036(this UIBlock InternalParameter_1045)
        {
            InternalType_5 InternalVar_1 = InternalParameter_1045.InternalMethod_3592();

            if (InternalVar_1 != null)
            {
                return InternalType_457.InternalProperty_190.InternalMethod_682(InternalVar_1);
            }

            return InternalParameter_1045.transform.parent != null ? InternalParameter_1045.transform.parent.localToWorldMatrix : Matrix4x4.identity;
        }

        public static Vector3 InternalMethod_1037(this UIBlock InternalParameter_1046)
        {
            return Vector3.Scale(InternalParameter_1046.RotatedSize, InternalParameter_1046.transform.lossyScale);
        }

        public static Vector3 InternalMethod_1038(this UIBlock InternalParameter_1047)
        {
            return Vector3.Scale(InternalParameter_1047.RotatedSize, InternalParameter_1047.transform.localScale);
        }

        public static Vector3 InternalMethod_1039(this UIBlock InternalParameter_1048)
        {
            return InternalParameter_1048.InternalMethod_1038() + InternalParameter_1048.CalculatedMargin.Size;
        }

        public static Vector3 InternalMethod_1035(this InternalType_5 InternalParameter_1044)
        {
            return InternalType_457.InternalProperty_190.InternalMethod_1851(InternalParameter_1044, InternalParameter_2049: true);
        }
    }
}