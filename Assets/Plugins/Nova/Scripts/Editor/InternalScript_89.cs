// Copyright (c) Supernova Technologies LLC
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_22.InternalNamespace_23
{
    internal static class InternalType_721 
    {
        public static bool InternalMethod_3255<AttributeType>(this MemberInfo InternalParameter_3014)
        {
            return InternalParameter_3014.GetCustomAttribute(typeof(AttributeType), false) != null;
        }
    }
}

