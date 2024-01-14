// Copyright (c) Supernova Technologies LLC
using TMPro;
using UnityEngine;

namespace Nova.TMP
{
    [AddComponentMenu("Nova/Text Mesh Pro - TextBlock")]
    public sealed class TextMeshProTextBlock : TextMeshPro
    {
        public override void SetVerticesDirty()
        {
            base.SetVerticesDirty();

            if (m_OnDirtyVertsCallback != null)
            {
                m_OnDirtyVertsCallback();
            }
        }

        internal void InternalMethod_3276() => SetActiveSubTextObjectRenderers(false);
    }
}
