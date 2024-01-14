// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.TMP;
using TMPro;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;
using static Nova.InternalNamespace_17.InternalNamespace_20.InternalType_592;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    
    internal class InternalType_548
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_2430 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_2431 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_2432 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_2433 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_2434 = false;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalField_2435 = false;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public string InternalProperty_458
        {
            get => InternalField_2436[0].text;
            set
            {
                InternalMethod_2202();
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
                {
                    InternalField_2436[InternalVar_1].text = value;
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public HorizontalAlignmentOptions InternalProperty_459
        {
            get => InternalField_2436[0].horizontalAlignment;
            set
            {
                InternalMethod_2202();
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
                {
                    InternalField_2436[InternalVar_1].horizontalAlignment = value;
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public VerticalAlignmentOptions InternalProperty_460
        {
            get => InternalField_2436[0].verticalAlignment;
            set
            {
                InternalMethod_2202();
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
                {
                    InternalField_2436[InternalVar_1].verticalAlignment = value;
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public Color InternalProperty_461
        {
            get => InternalField_2436[0].color;
            set
            {
                InternalMethod_2202();
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
                {
                    InternalField_2436[InternalVar_1].color = value;
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public TMP_FontAsset InternalProperty_462
        {
            get => InternalField_2436[0].font;
            set
            {
                InternalMethod_2202();
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
                {
                    InternalField_2436[InternalVar_1].font = value;
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public float InternalProperty_463
        {
            get => InternalField_2436[0].fontSize;
            set
            {
                InternalMethod_2202();
                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
                {
                    InternalField_2436[InternalVar_1].fontSize = value;
                }
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public TextMeshPro[] InternalField_2436 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public SerializedObject InternalField_2437 = null;

        private void InternalMethod_2202()
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2436.Length; InternalVar_1++)
            {
                Undo.RecordObject(InternalField_2436[InternalVar_1], "Inspector");
            }
        }

        public void InternalMethod_2203()
        {
            InternalField_2430 = InternalField_2431 = InternalField_2432 = InternalField_2433 = InternalField_2434 = InternalField_2435 = false;

            TextMeshPro InternalVar_1 = InternalField_2436[0];
            string InternalVar_2 = InternalVar_1.text;
            var InternalVar_3 = InternalVar_1.horizontalAlignment;
            var InternalVar_4 = InternalVar_1.verticalAlignment;
            var InternalVar_5 = InternalVar_1.color;
            var InternalVar_6 = InternalVar_1.font;
            var InternalVar_7 = InternalVar_1.fontSize;
            for (int InternalVar_8 = 1; InternalVar_8 < InternalField_2436.Length; InternalVar_8++)
            {
                TextMeshPro InternalVar_9 = InternalField_2436[InternalVar_8];
                if (InternalVar_9.text != InternalVar_2)
                {
                    InternalField_2430 = true;
                }

                if (!InternalVar_9.horizontalAlignment.Equals(InternalVar_3))
                {
                    InternalField_2431 = true;
                }

                if (!InternalVar_9.verticalAlignment.Equals(InternalVar_4))
                {
                    InternalField_2432 = true;
                }

                if (!InternalVar_9.color.Equals(InternalVar_5))
                {
                    InternalField_2433 = true;
                }

                if (!InternalVar_9.font.Equals(InternalVar_6))
                {
                    InternalField_2434 = true;
                }

                if (!InternalVar_9.fontSize.Equals(InternalVar_7))
                {
                    InternalField_2435 = true;
                }
            }
        }
    }

    [CustomEditor(typeof(TextBlock)), CanEditMultipleObjects]
    internal class InternalType_549 : InternalType_547<TextBlock>
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_548 InternalField_2438 = new InternalType_548();

        protected override void OnEnable()
        {
            base.OnEnable();

            InternalField_2438.InternalField_2436 = new TextMeshPro[InternalField_2385.Count];
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; InternalVar_1++)
            {
                InternalField_2438.InternalField_2436[InternalVar_1] = InternalField_2385[InternalVar_1].TMP;
            }

            InternalField_2438.InternalField_2437 = new SerializedObject(InternalField_2438.InternalField_2436);
        }

        protected override void InternalMethod_860()
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_2385.Count; InternalVar_1++)
            {
                InternalField_2211.Clear();
                InternalField_2385[InternalVar_1].GetComponents(InternalField_2211);

                int InternalVar_2 = -1;
                int InternalVar_3 = -1;
                for (int InternalVar_4 = 0; InternalVar_4 < InternalField_2211.Count; ++InternalVar_4)
                {
                    if (InternalField_2211[InternalVar_4] is TextMeshProTextBlock)
                    {
                        InternalVar_2 = InternalVar_4;
                    }
                    else if (InternalField_2211[InternalVar_4] is TextBlock)
                    {
                        InternalVar_3 = InternalVar_4;
                    }

                    if (InternalVar_3 >= 0 && InternalVar_2 >= 0)
                    {
                        break;
                    }
                }

                while (InternalVar_3 >= InternalVar_2 && ComponentUtility.MoveComponentUp(InternalField_2385[InternalVar_1]))
                {
                    InternalVar_3--;
                }
            }

            base.InternalMethod_860();
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private InternalType_602 InternalField_84 = new InternalType_602();
        protected override void InternalMethod_2184(TextBlock InternalParameter_2485)
        {
            InternalField_84.InternalProperty_954 = InternalField_2426.InternalProperty_568;
            bool InternalVar_1 = InternalField_84.InternalProperty_581 == InternalNamespace_0.InternalType_83.InternalField_282;

            InternalField_2438.InternalField_2437.UpdateIfRequiredOrScript();
            InternalField_2438.InternalMethod_2203();
            InternalType_576.InternalMethod_2321(InternalField_2427, InternalParameter_2485);
            InternalType_576.InternalMethod_2313(InternalField_2426, InternalParameter_2485);
            InternalType_576.InternalMethod_2311(InternalField_2426, InternalParameter_2485, InternalField_2425);
            InternalType_577.InternalMethod_2327(InternalField_2428, InternalField_2429, InternalField_2438);
            InternalType_576.InternalMethod_2320(InternalField_2426, InternalParameter_2485);

            bool InternalVar_2 = InternalField_84.InternalProperty_581 == InternalNamespace_0.InternalType_83.InternalField_282;

            if (InternalVar_2 && !InternalVar_1 && float.IsInfinity(InternalField_2426.InternalProperty_558.InternalProperty_546.InternalProperty_538))
            {
                for (int InternalVar_3 = 0; InternalVar_3 < InternalField_2385.Count; InternalVar_3++)
                {
                    InternalField_2385[InternalVar_3].TMP.DisableWordWrap();
                }
            }
        }
    }
}

