// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_25;
using Nova.InternalNamespace_0.InternalNamespace_12;
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A <see cref="UIBlock"/> for rendering text
    /// </summary>
    [ExecuteAlways, RequireComponent(typeof(TMP.TextMeshProTextBlock))]
    [AddComponentMenu("Nova/TextBlock")]
    [HelpURL("https://novaui.io/manual/TextBlock.html")]
    public sealed class TextBlock : UIBlock, InternalType_6
    {
        #region Public
        /// <summary>
        /// A shorthand for setting TMP.text
        /// </summary>
        public string Text
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => TMP.text;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                TMP.text = value;
            }
        }

        /// <summary>
        /// The TextMeshPro component attached to <c>this.gameObject</c>, used to generate the underlying text mesh.
        /// </summary>
        public TextMeshPro TMP
        {
            get
            {
                if (InternalField_3314 == null)
                {
                    InternalField_3314 = GetComponent<TextMeshPro>();
                }
                return InternalField_3314;
            }
        }

        /// <summary>
        /// The primary color of the text. Writes directly to <see cref="TMP"/>.Color.
        /// </summary>
        public override Color Color
        {
            get => TMP.color;
            set
            {
                TMP.color = value;
            }
        }

        /// <summary>
        /// Configures the render order of this UIBlock within a <see cref="SortGroup"/>.
        /// </summary>
        /// <remarks><see cref="UIBlock"/>s with a higher ZIndex are rendered on top of <see cref="UIBlock"/>s with a lower ZIndex.</remarks>
        public short ZIndex
        {
            get => visibility.ZIndex;
            set
            {
                visibility.ZIndex = value;
                InternalType_274.InternalProperty_190.InternalMethod_3031(this);
            }
        }

        /// <summary>
        /// The offset that is applied whenever text is being hugged (i.e. <see cref="UIBlock.AutoSize">AutoSize</see> is set to <see cref="AutoSize.Shrink">Shrink</see> on <c>x</c> or <c>y</c>).
        /// If text is not being hugged, this will be <see cref="Vector2.zero"/>.
        /// </summary>
        public Vector2 VisualOffset
        {
            get
            {
                if (!InternalProperty_27.InternalProperty_197 || !InternalProperty_436)
                {
                    return Vector2.zero;
                }

                ref InternalNamespace_0.InternalType_79 InternalVar_1 = ref InternalType_274.InternalProperty_190.InternalMethod_1265(this, -1);
                var InternalVar_2 = AutoSize.XY;
                bool2 InternalVar_3 = new bool2(InternalVar_2.X == Nova.AutoSize.Shrink, InternalVar_2.Y == Nova.AutoSize.Shrink);
                return InternalVar_1.InternalMethod_2606(InternalVar_3);
            }
        }
        #endregion

        #region Internal
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_670 InternalField_51 = InternalType_670.InternalField_2828;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        ref InternalNamespace_0.InternalType_79 InternalType_256<InternalNamespace_0.InternalType_79>.InternalProperty_270
        {
            get => throw new NotImplementedException("Shouldn't call this on text blocks");
        }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal bool2 InternalProperty_35
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => (AutoSize.XY == Nova.AutoSize.Shrink).InternalMethod_3297();
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_436
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => math.any(InternalProperty_35);
        }

        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalField_3350 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private bool InternalProperty_764
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => InternalField_3350;
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            set
            {
                InternalField_3350 = value;
            }
        }

        
        private bool InternalMethod_2726(InternalType_670 InternalParameter_3092)
        {

            if (InternalField_51 == InternalParameter_3092)
            {
                return false;
            }

            InternalField_51 = InternalParameter_3092;
            TMP.margin = InternalParameter_3092.InternalField_2829;

            return true;
        }

        
        void InternalType_6.InternalMethod_2724(ref InternalType_670 InternalParameter_3091)
        {
            InternalProperty_764 = true;

            if (!InternalMethod_2726(InternalParameter_3091))
            {
                return;
            }

            TMP.Rebuild(UnityEngine.UI.CanvasUpdate.PreRender);
            InternalMethod_2723();
        }

        
        private void InternalMethod_2723()
        {
            TMP_UpdateManager.UnRegisterTextElementForRebuild(TMP);
            TMP.isTextObjectScaleStatic = TMP.isTextObjectScaleStatic;
        }


        private void InternalMethod_128(TMP_TextInfo InternalParameter_80)
        {
            if (!InternalProperty_27.InternalProperty_197)
            {
                return;
            }


#pragma warning disable CS0162 
            if (NovaApplication.ConstIsEditor && TMP.textInfo.characterCount == 0 && !string.IsNullOrWhiteSpace(TMP.text))
            {
                this.InternalMethod_1959();
            }
#pragma warning restore CS0162 

            ref InternalNamespace_0.InternalType_79 InternalVar_1 = ref InternalType_274.InternalProperty_190.InternalMethod_1265(this, InternalParameter_80.meshInfo.Length);

            int InternalVar_2 = 0;
            for (int InternalVar_3 = 0; InternalVar_3 < InternalParameter_80.meshInfo.Length; InternalVar_3++)
            {
                if (InternalVar_3 != 0)
                {
                    InternalParameter_80.meshInfo[InternalVar_3].ClearUnusedVertices();
                }
                InternalVar_2 += InternalParameter_80.meshInfo[InternalVar_3].vertices.Length;
            }

            InternalVar_2 /= 4;

            if (InternalVar_2 == 0 && InternalVar_1.InternalField_3197 == 0)
            {
                return;
            }
            InternalVar_1.InternalField_3197 = InternalVar_2;
            InternalVar_1.InternalField_264 = transform.lossyScale.y;

            float2 InternalVar_4 = InternalNamespace_0.InternalNamespace_5.InternalType_187.InternalField_2247;
            float2 InternalVar_5 = InternalNamespace_0.InternalNamespace_5.InternalType_187.InternalField_525;
            for (int InternalVar_6 = 0; InternalVar_6 < InternalParameter_80.characterCount; InternalVar_6++)
            {
                var InternalVar_7 = InternalParameter_80.characterInfo[InternalVar_6];
                InternalVar_4 = math.min(InternalVar_4, new float2(InternalVar_7.origin, InternalVar_7.descender));
                InternalVar_5 = math.max(InternalVar_5, new float2(InternalVar_7.xAdvance, InternalVar_7.ascender));
            }

            if (InternalParameter_80.characterCount == 0)
            {
                InternalVar_4 = float2.zero;
                InternalVar_5 = float2.zero;
            }

            InternalVar_1.InternalField_262 = new InternalType_306(InternalVar_4, InternalVar_5);


            int InternalVar_8 = InternalParameter_80.meshInfo.Length - 1;
            if (InternalVar_8 > 0)
            {
                (TMP as TMP.TextMeshProTextBlock).InternalMethod_3276();
            }

            for (int InternalVar_9 = 0; InternalVar_9 < InternalVar_1.InternalField_261.InternalProperty_216; ++InternalVar_9)
            {
                ref InternalNamespace_0.InternalType_110 InternalVar_10 = ref InternalVar_1.InternalField_261.InternalMethod_800(InternalVar_9);
                int InternalVar_11 = InternalParameter_80.meshInfo[InternalVar_9].material.GetInstanceID();
                if (InternalVar_10.InternalField_354 != InternalVar_11)
                {
                    InternalType_274.InternalProperty_190.InternalField_875[InternalVar_11] = InternalParameter_80.meshInfo[InternalVar_9].material;
                }

                TMP_MeshInfo InternalVar_12 = InternalParameter_80.meshInfo[InternalVar_9];
                InternalVar_10.InternalMethod_553(InternalVar_12);
                unsafe
                {
                    TMPUtils.CopyUVs(InternalVar_10.InternalField_357.InternalProperty_232, InternalVar_10.InternalField_358.InternalProperty_232, ref InternalVar_12);
                }
            }

            InternalType_457.InternalProperty_190.InternalMethod_1846(this, InternalVar_1.InternalField_262.InternalMethod_1363().xy);
        }

        private protected override void InternalMethod_111()
        {
            InternalField_51 = InternalType_670.InternalField_2828;
            InternalMethod_130();
            TMP.OnPreRenderText += InternalProperty_41;
            TMP.RegisterDirtyVerticesCallback(InternalProperty_40);

            InternalMethod_136(this);

            InternalProperty_38.hideFlags = HideFlags.HideInInspector;
            InternalProperty_38.enabled = false;

            base.InternalMethod_111();
        }

        private protected override void InternalMethod_112()
        {
            TMP.OnPreRenderText -= InternalProperty_41;
            TMP.UnregisterDirtyVerticesCallback(InternalProperty_40);
            InternalMethod_137(this);
            base.InternalMethod_112();
        }

        
        private void InternalMethod_127()
        {

            if (!InternalProperty_764)
            {
                InternalMethod_2723();
            }
            else if (InternalProperty_25 && !TMP.enabled)
            {
                ref InternalNamespace_0.InternalType_79 InternalVar_1 = ref InternalType_274.InternalProperty_190.InternalMethod_1265(this, TMP.textInfo.meshInfo.Length);
                InternalVar_1.InternalField_3197 = 0;
                InternalVar_1.InternalField_262 = default;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly Vector2 InternalField_52 = .5f * Vector2.one;
        private void InternalMethod_130()
        {
            InternalProperty_37.anchorMin = InternalField_52;
            InternalProperty_37.anchorMax = InternalField_52;
            InternalProperty_37.sizeDelta = Vector2.zero;
        }

        internal override void InternalMethod_1856()
        {
            base.InternalMethod_1856();

            if (!InternalProperty_25 || !InternalProperty_764)
            {
                return;
            }

            InternalMethod_2726(InternalType_670.InternalMethod_2348(CalculatedSize.XY.Value, SizeMinMax.InternalMethod_2990().InternalProperty_121.xy, InternalProperty_35));
        }


        #region 
        [NonSerialized, HideInInspector]
[System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private TextMeshPro InternalField_3314 = null;

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private RectTransform InternalField_3310 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private RectTransform InternalProperty_37
        {
            get
            {
                if (InternalField_3310 == null)
                {
                    InternalField_3310 = GetComponent<RectTransform>();
                }
                return InternalField_3310;
            }
        }

        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private MeshRenderer InternalField_3309 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private MeshRenderer InternalProperty_38
        {
            get
            {
                if (InternalField_3309 == null)
                {
                    InternalField_3309 = GetComponent<MeshRenderer>();
                }
                return InternalField_3309;
            }
        }

        
        [NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UnityEngine.Events.UnityAction InternalField_54 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private UnityEngine.Events.UnityAction InternalProperty_40
        {
            get
            {
                if (InternalField_54 == null)
                {
                    InternalField_54 = InternalMethod_127;
                }

                return InternalField_54;
            }
        }

        
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                private Action<TMP_TextInfo> InternalField_55 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private Action<TMP_TextInfo> InternalProperty_41
        {
            get
            {
                if (InternalField_55 == null)
                {
                    InternalField_55 = InternalMethod_128;
                }

                return InternalField_55;
            }
        }
        #endregion

        #region 
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                        private static HashSet<TextBlock> InternalField_56 = new HashSet<TextBlock>();
        private static void InternalMethod_136(TextBlock InternalParameter_81)
        {
            if (!InternalField_56.Add(InternalParameter_81))
            {
                return;
            }

            if (InternalField_56.Count == 1)
            {
                TMPro_EventManager.TEXT_CHANGED_EVENT.Add(InternalMethod_138);
            }
        }

        private static void InternalMethod_137(TextBlock InternalParameter_82)
        {
            if (!InternalField_56.Remove(InternalParameter_82))
            {
                return;
            }

            if (InternalField_56.Count == 0)
            {
                TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(InternalMethod_138);
            }
        }

        
        private static void InternalMethod_138(UnityEngine.Object InternalParameter_83)
        {
            if (!(InternalParameter_83 is TextMeshPro textMeshPro))
            {
                return;
            }



            TextBlock InternalVar_1 = textMeshPro.gameObject.GetComponent<TextBlock>();
            if (InternalVar_1 == null)
            {
                return;
            }

            if (InternalVar_1.TMP.textInfo.characterCount > 0)
            {
                return;
            }

            InternalVar_1.InternalMethod_128(InternalVar_1.TMP.textInfo);
        }
        #endregion

        private TextBlock() : base()
        {
            visibility = InternalType_36.InternalMethod_307(InternalType_11.InternalField_65);
        }
        #endregion
    }
}
