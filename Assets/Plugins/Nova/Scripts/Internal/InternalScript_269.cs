// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_9;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Nova.InternalNamespace_0
{
    [Serializable]
    internal class InternalType_100 : IDisposable
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly InternalType_100 InternalField_312 = new InternalType_100(null);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static Dictionary<InternalType_131, InternalType_100> InternalField_313 = new Dictionary<InternalType_131, InternalType_100>();

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public bool InternalProperty_180 => owner != null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public CoreBlock InternalProperty_181 => owner;

        [SerializeReference, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<InternalType_34> InternalField_314 = null;
        [NonSerialized, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<InternalType_131> InternalField_315 = null;
        [SerializeField, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private int childrenPerVirtualBlock;
        [SerializeField, HideInInspector]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private CoreBlock owner = null;

        public void InternalMethod_531()
        {
            if (InternalField_314 == null)
            {
                return;
            }

            if (InternalField_315 == null)
            {
                InternalField_315 = new List<InternalType_131>();
            }

            InternalField_315.Clear();
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_314.Count; ++InternalVar_1)
            {
                InternalField_315.Add(InternalField_314[InternalVar_1].InternalProperty_83);
            }

            InternalField_313[owner.InternalProperty_29] = this;
        }

        public InternalType_100(CoreBlock InternalParameter_403)
        {
            this.owner = InternalParameter_403;

            if (InternalParameter_403 != null)
            {
                InternalField_313.Add(InternalParameter_403.InternalProperty_29, this);
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_521<InternalType_131> InternalProperty_182
        {
            get
            {
                return InternalField_315 == null ? InternalType_521<InternalType_131>.InternalProperty_435 : InternalField_315.InternalMethod_2043();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public InternalType_521<InternalType_34> InternalProperty_183
        {
            get
            {
                return InternalField_314 == null ? InternalType_521<InternalType_34>.InternalProperty_435 : InternalField_314.InternalMethod_2043();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int InternalProperty_184 => InternalField_314 == null ? 0 : InternalField_314.Count;

        public void InternalMethod_536(InternalType_34 InternalParameter_404, int InternalParameter_405, bool InternalParameter_406)
        {
            if (!InternalProperty_180)
            {
                return;
            }

            if (InternalField_314 == null)
            {
                InternalField_314 = new List<InternalType_34>();
            }

            if (InternalField_315 == null || InternalField_315.Count != InternalField_314.Count)
            {
                InternalMethod_531();
            }

            childrenPerVirtualBlock = InternalParameter_405;

            if (owner.InternalProperty_25)
            {
                InternalType_253.InternalProperty_190.InternalMethod_1150(InternalParameter_404, owner.InternalProperty_29, InternalParameter_405, InternalParameter_406);
            }

            if (InternalParameter_406)
            {
                InternalField_314.Insert(0, InternalParameter_404);
                InternalField_315.Insert(0, InternalParameter_404.InternalProperty_83);

                for (int InternalVar_1 = 0; InternalVar_1 < InternalField_314.Count; ++InternalVar_1)
                {
                    InternalField_314[InternalVar_1].InternalMethod_282(InternalVar_1);
                }
            }
            else
            {
                InternalField_314.Add(InternalParameter_404);
                InternalField_315.Add(InternalParameter_404.InternalProperty_83);
                InternalParameter_404.InternalMethod_282(InternalField_315.Count - 1);
            }
        }

        public void InternalMethod_537(InternalType_34 InternalParameter_407, int InternalParameter_408)
        {
            if (InternalField_314 == null)
            {
                return;
            }

            int InternalVar_1 = InternalParameter_407.InternalProperty_209;
            if (InternalVar_1 == InternalParameter_408)
            {
                return;
            }

            if (InternalField_314[InternalVar_1] != InternalParameter_407)
            {
                Debug.LogError($"Virtual Block not found at current index, {InternalVar_1}.");

                return;
            }

            if (owner.InternalProperty_25)
            {
                InternalType_253.InternalProperty_190.InternalMethod_1151(((InternalType_134)InternalParameter_407).InternalProperty_196, owner.InternalProperty_29, InternalParameter_408);
            }

            InternalField_314.RemoveAt(InternalVar_1);
            InternalField_315.RemoveAt(InternalVar_1);

            InternalField_314.Insert(InternalParameter_408, InternalParameter_407);
            InternalField_315.Insert(InternalParameter_408, InternalParameter_407.InternalProperty_83);

            for (int InternalVar_2 = Mathf.Min(InternalVar_1, InternalParameter_408); InternalVar_2 < InternalField_314.Count; ++InternalVar_2)
            {
                InternalField_314[InternalVar_2].InternalMethod_282(InternalVar_2);
            }
        }

        public void InternalMethod_538(InternalType_34 InternalParameter_409)
        {
            if (InternalField_314 == null)
            {
                return;
            }

            if (!owner.InternalProperty_25)
            {
                return;
            }

            int InternalVar_1 = InternalField_314.LastIndexOf(InternalParameter_409);

            if (InternalVar_1 < 0)
            {
                return;
            }

            InternalField_314.RemoveAt(InternalVar_1);
            InternalField_315.RemoveAt(InternalVar_1);

            InternalType_253.InternalProperty_190.InternalMethod_1152(InternalParameter_409);

            for (int InternalVar_2 = InternalVar_1; InternalVar_2 < InternalField_314.Count; ++InternalVar_2)
            {
                InternalField_314[InternalVar_2].InternalMethod_282(InternalVar_2);
            }

            InternalParameter_409.InternalMethod_282(InternalType_34.InternalField_121);
        }

        public void InternalMethod_3740(int InternalParameter_3522)
        {
            if (InternalField_314 == null)
            {
                return;
            }

            if (!owner.InternalProperty_25)
            {
                return;
            }

            InternalType_253.InternalProperty_190.InternalMethod_3744(owner.InternalProperty_29, InternalParameter_3522);
        }

        public void InternalMethod_539()
        {
            if (InternalField_314 == null)
            {
                return;
            }

            for (int InternalVar_1 = InternalField_314.Count - 1; InternalVar_1 >= 0; --InternalVar_1)
            {
                InternalType_34 InternalVar_2 = InternalField_314[InternalVar_1];
                InternalVar_2.InternalMethod_290();
                InternalType_253.InternalProperty_190.InternalMethod_1152(InternalVar_2);
                InternalVar_2.InternalMethod_282(InternalType_34.InternalField_121);
                InternalVar_2.Dispose();
            }
        }

        public void InternalMethod_540()
        {
            if (InternalField_314 == null)
            {
                return;
            }

            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_314.Count; ++InternalVar_1)
            {
                InternalType_34 InternalVar_2 = InternalField_314[InternalVar_1];
                InternalVar_2.InternalMethod_287();
                InternalType_253.InternalProperty_190.InternalMethod_1150(InternalVar_2, owner.InternalProperty_29, childrenPerVirtualBlock, InternalParameter_1235: false);
                InternalVar_2.InternalMethod_282(InternalVar_1);
            }
        }

        public void Dispose()
        {
            if (owner != null)
            {
                InternalField_313.Remove(owner.InternalProperty_29);
            }

            if (InternalField_314 == null)
            {
                return;
            }

            for (int InternalVar_1 = InternalField_314.Count - 1; InternalVar_1 >= 0; --InternalVar_1)
            {
                InternalType_34 InternalVar_2 = InternalField_314[InternalVar_1];
                InternalMethod_538(InternalVar_2);
                InternalVar_2.Dispose();
            }
        }

        public static InternalType_100 InternalMethod_541(InternalType_131 InternalParameter_410, CoreBlock InternalParameter_411)
        {
            if (!InternalField_313.TryGetValue(InternalParameter_410, out InternalType_100 InternalVar_1))
            {
                return InternalField_312;
            }

            return InternalVar_1.InternalMethod_542(InternalParameter_411);
        }

        private InternalType_100 InternalMethod_542(CoreBlock InternalParameter_412)
        {
            if (InternalField_314 == null)
            {
                return InternalField_312;
            }

            InternalType_100 InternalVar_1 = new InternalType_100(InternalParameter_412);

            for (int InternalVar_2 = 0; InternalVar_2 < InternalField_314.Count; ++InternalVar_2)
            {
                InternalVar_1.InternalMethod_536(InternalField_314[InternalVar_2].InternalMethod_293(), childrenPerVirtualBlock, InternalParameter_406: false);
            }

            return InternalVar_1;
        }
    }
}
