// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_17.InternalNamespace_22;
using UnityEditor;
using UnityEditor.Presets;
using UnityEngine;

namespace Nova.InternalNamespace_17
{
    internal static class InternalType_533
    {
        [MenuItem("GameObject/Nova/UIBlock 2D", false, 8)]
        private static void InternalMethod_2109(MenuCommand InternalParameter_2435)
        {
            InternalMethod_2113<UIBlock2D, InternalNamespace_21.InternalType_713>(InternalParameter_2435, "UIBlock2D").InternalMethod_73();
        }

        [MenuItem("GameObject/Nova/TextBlock", false, 9)]
        private static void InternalMethod_2110(MenuCommand InternalParameter_2436)
        {
            InternalMethod_2113<TextBlock, InternalNamespace_21.InternalType_713>(InternalParameter_2436, "TextBlock").InternalMethod_73();
        }

        [MenuItem("GameObject/Nova/UIBlock 3D", false, 10)]
        private static void InternalMethod_2111(MenuCommand InternalParameter_2437)
        {
            InternalMethod_2113<UIBlock3D, InternalNamespace_21.InternalType_713>(InternalParameter_2437, "UIBlock3D").InternalMethod_73();
        }

        [MenuItem("GameObject/Nova/UIBlock", false, 11)]
        private static void InternalMethod_2112(MenuCommand InternalParameter_2438)
        {
            InternalMethod_2113<UIBlock, InternalNamespace_21.InternalType_713>(InternalParameter_2438, "UIBlock").InternalMethod_73();
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/Button", false, 112)]
#else
        [MenuItem("GameObject/Nova/Controls/Button", false, 12)]
#endif
        private static void InternalMethod_3191(MenuCommand InternalParameter_2769)
        {
            if (NovaSettings.InternalProperty_89.ButtonPrefab == null)
            {
                Debug.LogError("Button prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.ButtonPrefab, InternalParameter_2769);
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/Toggle", false, 113)]
#else
        [MenuItem("GameObject/Nova/Controls/Toggle", false, 13)]
#endif
        private static void InternalMethod_0(MenuCommand InternalParameter_2881)
        {
            if (NovaSettings.InternalProperty_89.TogglePrefab == null)
            {
                Debug.LogError("Toggle prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.TogglePrefab, InternalParameter_2881);
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/Slider", false, 114)]
#else
        [MenuItem("GameObject/Nova/Controls/Slider", false, 14)]
#endif
        private static void InternalMethod_2974(MenuCommand InternalParameter_4)
        {
            if (NovaSettings.InternalProperty_89.SliderPrefab == null)
            {
                Debug.LogError("Slider prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.SliderPrefab, InternalParameter_4);
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/Dropdown", false, 115)]
#else
        [MenuItem("GameObject/Nova/Controls/Dropdown", false, 15)]
#endif
        private static void InternalMethod_3190(MenuCommand InternalParameter_3)
        {
            if (NovaSettings.InternalProperty_89.DropdownPrefab == null)
            {
                Debug.LogError("Dropdown prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.DropdownPrefab, InternalParameter_3);
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/Text Field", false, 116)]
#else
        [MenuItem("GameObject/Nova/Controls/Text Field", false, 16)]
#endif
        private static void InternalMethod_4(MenuCommand InternalParameter_10)
        {
            if (NovaSettings.InternalProperty_89.TextFieldPrefab == null)
            {
                Debug.LogError("Text Field prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.TextFieldPrefab, InternalParameter_10);
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/Scroll View", false, 117)]
#else
        [MenuItem("GameObject/Nova/Controls/Scroll View", false, 17)]
#endif
        private static void InternalMethod_3(MenuCommand InternalParameter_748)
        {
            if (NovaSettings.InternalProperty_89.ScrollViewPrefab == null)
            {
                Debug.LogError("Scroll View prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.ScrollViewPrefab, InternalParameter_748);
        }

#if UNITY_2021_1_OR_NEWER
        [MenuItem("GameObject/Nova/UI Root", false, 118)]
#else
        [MenuItem("GameObject/Nova/Controls/UI Root", false, 18)]
#endif
        private static void InternalMethod_10(MenuCommand InternalParameter_747)
        {
            if (NovaSettings.InternalProperty_89.UIRootPrefab == null)
            {
                Debug.LogError("UI Root prefab source unassigned. A prefab can be assigned under Project Settings > Nova.");
                return;
            }

            InternalMethod_864(NovaSettings.InternalProperty_89.UIRootPrefab, InternalParameter_747);
        }

        private static void InternalMethod_864(UIBlock InternalParameter_746, MenuCommand InternalParameter_745)
        {
            bool InternalVar_1 = !Application.IsPlaying(UnityEditor.SceneManagement.StageUtility.GetCurrentStage());

            GameObject InternalVar_2 =  InternalVar_1 ? (PrefabUtility.InstantiatePrefab(InternalParameter_746) as UIBlock).gameObject : Object.Instantiate(InternalParameter_746).gameObject;

            if (InternalParameter_745.context is GameObject parent)
            {
                GameObjectUtility.SetParentAndAlign(InternalVar_2, parent);
            }
            else
            {
                UnityEditor.SceneManagement.StageUtility.PlaceGameObjectInCurrentStage(InternalVar_2);
            }

            if (InternalVar_2 != null)
            {
                InternalVar_2.transform.SetAsLastSibling();
            }

            Selection.activeObject = InternalVar_2;
        }

        private static T InternalMethod_2113<T, TTool>(MenuCommand InternalParameter_2439, string InternalParameter_2440 = "GameObject") where T : Component where TTool : UnityEditor.EditorTools.EditorTool
        {
            GameObject InternalVar_1 = new GameObject(InternalParameter_2440);

            if (InternalParameter_2439.context is GameObject parent)
            {
                GameObjectUtility.SetParentAndAlign(InternalVar_1, parent);
            }
            else
            {
                UnityEditor.SceneManagement.StageUtility.PlaceGameObjectInCurrentStage(InternalVar_1);
            }

            T InternalVar_2 = InternalVar_1.AddComponent<T>();

            Preset[] InternalVar_3 = Preset.GetDefaultPresetsForObject(InternalVar_2);

            if (InternalVar_3 != null && InternalVar_3.Length > 0 && InternalVar_3[0] != null)
            {
                InternalVar_3[0].ApplyTo(InternalVar_2);
            }

            Undo.RegisterCreatedObjectUndo(InternalVar_1, "Create " + InternalVar_1.name);
            Selection.activeGameObject = InternalVar_1;

            EditorApplication.delayCall += () =>
            {
                if (!InternalType_779.InternalMethod_3699<T>(out _))
                {
                    return;
                }

                UnityEditor.EditorTools.ToolManager.SetActiveTool<TTool>();
            };

            return InternalVar_2;
        }
    }
}

