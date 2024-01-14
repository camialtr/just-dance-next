// Copyright (c) Supernova Technologies LLC
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17
{
    [CustomEditor(typeof(UIBlockActivator))]
    internal class InternalType_530 : UnityEditor.Editor
    {
        public override void OnInspectorGUI() { hideFlags = target.hideFlags | HideFlags.HideInInspector; }
        protected override void OnHeaderGUI() { }
        protected override bool ShouldHideOpenButton() => true;

        private void OnEnable()
        {
            hideFlags = target.hideFlags | HideFlags.HideInInspector;
        }
    }
}
