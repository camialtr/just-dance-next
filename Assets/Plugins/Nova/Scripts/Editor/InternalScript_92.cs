// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_18;
using Nova.InternalNamespace_0.InternalNamespace_5;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    internal static class InternalType_720
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly float InternalField_3298 = EditorGUIUtility.singleLineHeight + InternalType_573.InternalField_2557;

        public static Rect InternalMethod_3441(this ref Rect InternalParameter_3222, float InternalParameter_3223)
        {
            return new Rect(InternalParameter_3222.x + (InternalParameter_3222.width - InternalParameter_3223) * 0.5f, InternalParameter_3222.y, InternalParameter_3223, InternalParameter_3222.height);
        }

        public static Rect InternalMethod_3677(this ref Rect InternalParameter_3469, Vector2 InternalParameter_3470)
        {
            return new Rect(InternalParameter_3469.x + (InternalParameter_3469.width - InternalParameter_3470.x) * 0.5f, InternalParameter_3469.y + (InternalParameter_3469.height - InternalParameter_3470.y) * 0.5f, InternalParameter_3470.x, InternalParameter_3470.y);
        }

        public static Rect InternalMethod_3442(this ref Rect InternalParameter_3224, float InternalParameter_3225, float InternalParameter_3226)
        {
            return new Rect(InternalParameter_3224.xMax - InternalParameter_3225, InternalParameter_3224.y, InternalParameter_3225, InternalParameter_3226);
        }

        public static Rect InternalMethod_3443(this ref Rect InternalParameter_3227, float InternalParameter_3228, float InternalParameter_3229)
        {
            return new Rect(InternalParameter_3227.xMax - InternalParameter_3228, InternalParameter_3227.yMax - InternalParameter_3229, InternalParameter_3228, InternalParameter_3229);
        }

        public static void InternalMethod_3247(this ref Rect InternalParameter_2992, out Rect InternalParameter_2993, out Rect InternalParameter_2994)
        {
            float InternalVar_1 = (InternalParameter_2992.width - InternalType_573.InternalField_2557) * .5f;
            InternalParameter_2993 = new Rect(InternalParameter_2992.x, InternalParameter_2992.y, InternalVar_1, InternalParameter_2992.height);
            InternalParameter_2994 = new Rect(InternalParameter_2992.x + InternalParameter_2993.width + InternalType_573.InternalField_2557, InternalParameter_2992.y, InternalVar_1, InternalParameter_2992.height);
        }

        public static void InternalMethod_3248(this ref Rect InternalParameter_2995, out Rect InternalParameter_2996, out Rect InternalParameter_2997, out Rect InternalParameter_2998)
        {
            float InternalVar_1 = (InternalParameter_2995.width - 2f * InternalType_573.InternalField_2557) / 3f;
            InternalParameter_2996 = InternalParameter_2995;
            InternalParameter_2996.width = InternalVar_1;
            InternalParameter_2997 = InternalParameter_2998 = InternalParameter_2996;
            InternalParameter_2997.x += InternalParameter_2996.width + InternalType_573.InternalField_2557;
            InternalParameter_2998.x = InternalParameter_2997.x + InternalParameter_2996.width + InternalType_573.InternalField_2557;
        }

        public static void InternalMethod_3249(this ref Rect InternalParameter_2999, float InternalParameter_3000, out Rect InternalParameter_3001, out Rect InternalParameter_3002)
        {
            InternalParameter_3001 = new Rect(InternalParameter_2999.x, InternalParameter_2999.y, InternalParameter_3000, InternalParameter_2999.height);
            InternalParameter_3002 = new Rect(InternalParameter_3001.xMax + InternalType_573.InternalField_2557, InternalParameter_2999.y, InternalParameter_2999.width - InternalParameter_3000 - InternalType_573.InternalField_2557, InternalParameter_2999.height);
        }

        public static void InternalMethod_3251(this ref Rect InternalParameter_3007)
        {
            InternalParameter_3007.InternalMethod_3444(InternalField_3298);
        }

        public static void InternalMethod_3444(this ref Rect InternalParameter_3230, float InternalParameter_3231)
        {
            InternalParameter_3230 = new Rect(InternalParameter_3230.x, InternalParameter_3230.y + InternalParameter_3231, InternalParameter_3230.width, InternalParameter_3230.height);
        }

        public static void InternalMethod_3252(this ref Rect InternalParameter_3008, float InternalParameter_3009)
        {
            InternalParameter_3008 = new Rect(InternalParameter_3008.x + InternalParameter_3009, InternalParameter_3008.y, InternalParameter_3008.width - InternalParameter_3009, InternalParameter_3008.height);
        }

        public static void InternalMethod_3253(this ref Rect InternalParameter_3010) => InternalParameter_3010.InternalMethod_3252(EditorGUIUtility.labelWidth);

        
        public static Rect InternalMethod_3254(ref this Rect InternalParameter_3011, float InternalParameter_3012 = -1f, float InternalParameter_3013 = InternalType_178.InternalField_471)
        {
            if (InternalParameter_3012 == -1f)
            {
                InternalParameter_3012 = EditorGUIUtility.singleLineHeight;
            }

            Rect InternalVar_1 = InternalParameter_3011;
            InternalVar_1.height = InternalParameter_3012;

            float InternalVar_2 = InternalParameter_3012 + InternalParameter_3013;
            InternalParameter_3011.y += InternalVar_2;
            InternalParameter_3011.height -= InternalVar_2;
            return InternalVar_1;
        }
    }
}

