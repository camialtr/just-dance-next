// Copyright (c) Supernova Technologies LLC
using System;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_22
{
    internal static class InternalType_779
    {
        
        public static bool InternalMethod_3699<T>(out Type InternalParameter_3513) where T : Component
        {
            UnityEditor.Editor[] InternalVar_1 = ActiveEditorTracker.sharedTracker.activeEditors;

            InternalParameter_3513 = null;

            if (InternalVar_1 == null)
            {
                return false;
            }

            for (int InternalVar_2 = 0; InternalVar_2 < InternalVar_1.Length; ++InternalVar_2)
            {
                UnityEditor.Editor InternalVar_3 = InternalVar_1[InternalVar_2];

                if (InternalVar_3 == null || InternalVar_3.target == null)
                {
                    continue;
                }

                Type InternalVar_4 = InternalVar_3.target.GetType();

                if (typeof(T).IsAssignableFrom(InternalVar_4))
                {
                    InternalParameter_3513 = InternalVar_4;
                    return true;
                }
            }

            return false;
        }
    }
}
