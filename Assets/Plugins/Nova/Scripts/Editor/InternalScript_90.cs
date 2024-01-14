// Copyright (c) Supernova Technologies LLC
using System.Collections.Generic;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_22.InternalNamespace_23
{
    internal static class InternalType_722
    {
        public static List<T> InternalMethod_3256<T>(this Object[] InternalParameter_3015)
        {
            List<T> InternalVar_1 = new List<T>();
            for (int InternalVar_2 = 0; InternalVar_2 < InternalParameter_3015.Length; ++InternalVar_2)
            {
                if (InternalParameter_3015[InternalVar_2] is T t)
                {
                    InternalVar_1.Add(t);
                }
            }
            return InternalVar_1;
        }
    }
}

