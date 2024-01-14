// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova.InternalNamespace_0.InternalNamespace_8
{
    internal class InternalType_520<T73> : InternalType_519
    {
        public override void InternalMethod_2042(ItemView InternalParameter_2366, InternalType_518 InternalParameter_2365, int InternalParameter_2364)
        {
            if (!InternalParameter_2365.InternalMethod_2035(InternalParameter_2364, out T73 InternalVar_1) && InternalParameter_2364 >= 0 && InternalParameter_2364 < InternalParameter_2365.InternalProperty_430)
            {
                Debug.LogError("Mismatch between prefab and data type. Unable to invoke OnBind event");
                return;
            }


            InternalParameter_2366.InternalMethod_163(InternalVar_1);
        }

        public override void InternalMethod_2041(ItemView InternalParameter_2363, InternalType_518 InternalParameter_2362, int InternalParameter_2361)
        {
            if (!InternalParameter_2362.InternalMethod_2035(InternalParameter_2361, out T73 InternalVar_1) && InternalParameter_2361 >= 0 && InternalParameter_2361 < InternalParameter_2362.InternalProperty_430)
            {
                Debug.LogError("Mismatch between prefab and data type. Unable to invoke OnUnbind event");
                return;
            }


            InternalParameter_2363.InternalMethod_164(InternalVar_1);
        }
    }

    
    internal abstract class InternalType_519
    {
        public abstract void InternalMethod_2042(ItemView InternalParameter_2366, InternalType_518 InternalParameter_2365, int InternalParameter_2364);
        public abstract void InternalMethod_2041(ItemView InternalParameter_2363, InternalType_518 InternalParameter_2362, int InternalParameter_2361);
    }
}
