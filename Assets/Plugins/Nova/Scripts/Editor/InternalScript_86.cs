// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_10;
using Nova.InternalNamespace_0.InternalNamespace_5;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering;

namespace Nova.InternalNamespace_17.InternalNamespace_24
{
    internal class InternalType_724 : IPreprocessShaders
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_2266 = "Hidden/Nova/Nova";

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public int callbackOrder => 0;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private List<ShaderKeyword> InternalField_3299 = new List<ShaderKeyword>();
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<string> InternalField_3300 = new List<string>()
        {
            "FOG_LINEAR",
            "FOG_EXP",
            "FOG_EXP2",
            "DYNAMICLIGHTMAP_ON",
            "LIGHTMAP_ON",
            "LIGHTMAP_SHADOW_MIXING",
            "DIRLIGHTMAP_COMBINED",
        };

        public void OnProcessShader(Shader shader, ShaderSnippetData snippet, IList<ShaderCompilerData> data)
        {
            if (!shader.name.Contains(InternalField_2266))
            {
                return;
            }

            if (!InternalMethod_3321(shader.name))
            {
                data.Clear();
                return;
            }

            InternalMethod_3263(shader);
            for (int InternalVar_1 = data.Count - 1; InternalVar_1 >= 0; --InternalVar_1)
            {
                for (int InternalVar_2 = 0; InternalVar_2 < InternalField_3299.Count; ++InternalVar_2)
                {
                    if (data[InternalVar_1].shaderKeywordSet.IsEnabled(InternalField_3299[InternalVar_2]))
                    {
                        data.RemoveAt(InternalVar_1);
                        break;
                    }
                }
            }
        }

        private void InternalMethod_3263(Shader InternalParameter_3025)
        {
            InternalField_3299.Clear();
            for (int InternalVar_1 = 0; InternalVar_1 < InternalField_3300.Count; ++InternalVar_1)
            {
                InternalField_3299.Add(new ShaderKeyword(InternalParameter_3025, InternalField_3300[InternalVar_1]));
            }
        }

        private bool InternalMethod_3321(string InternalParameter_3124)
        {
            if (!InternalMethod_3323(InternalParameter_3124, out InternalNamespace_0.InternalType_104 InternalVar_1) ||
                !InternalMethod_3322(InternalParameter_3124, out InternalType_266 InternalVar_2) ||
                !InternalNamespace_0.InternalType_24.InternalProperty_1040)
            {
                return false;
            }

            return InternalType_409.InternalMethod_1925(InternalVar_2, InternalVar_1);
        }

        private bool InternalMethod_3322(string InternalParameter_3125, out InternalType_266 InternalParameter_3126)
        {
            if (InternalParameter_3125.Contains("UIBlock2D"))
            {
                InternalParameter_3126 = InternalType_266.InternalField_786;
                return true;
            }
            else if (InternalParameter_3125.Contains("DropShadow"))
            {
                InternalParameter_3126 = InternalType_266.InternalField_789;
                return true;
            }
            else if (InternalParameter_3125.Contains("UIBlock3D"))
            {
                InternalParameter_3126 = InternalType_266.InternalField_787;
                return true;
            }
            else if (InternalParameter_3125.Contains("TextBlock"))
            {
                InternalParameter_3126 = InternalType_266.InternalField_788;
                return true;
            }
            else
            {
                Debug.LogWarning($"Failed to get visual type from shader name: {InternalParameter_3125}");
                InternalParameter_3126 = InternalType_266.InternalField_785;
                return false;
            }
        }

        private bool InternalMethod_3323(string InternalParameter_3127, out InternalNamespace_0.InternalType_104 InternalParameter_3128)
        {
            if (InternalParameter_3127.Contains("Unlit"))
            {
                InternalParameter_3128 = InternalNamespace_0.InternalType_104.InternalField_323;
                return true;
            }
            if (InternalParameter_3127.Contains("Lambert"))
            {
                InternalParameter_3128 = InternalNamespace_0.InternalType_104.InternalField_324;
                return true;
            }
            else if (InternalParameter_3127.Contains("BlinnPhong"))
            {
                InternalParameter_3128 = InternalNamespace_0.InternalType_104.InternalField_325;
                return true;
            }
            else if (InternalParameter_3127.Contains("StandardSpecular"))
            {
                InternalParameter_3128 = InternalNamespace_0.InternalType_104.InternalField_327;
                return true;
            }
            else if (InternalParameter_3127.Contains("Standard"))
            {
                InternalParameter_3128 = InternalNamespace_0.InternalType_104.InternalField_326;
                return true;
            }
            else
            {
                Debug.LogWarning($"Failed to get lighting model from shader name: {InternalParameter_3127}");
                InternalParameter_3128 = default;
                return false;
            }
        }
    }

}
