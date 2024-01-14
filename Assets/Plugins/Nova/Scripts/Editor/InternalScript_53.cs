// Copyright (c) Supernova Technologies LLC
using Nova.Compat;
using Nova.InternalNamespace_17.InternalNamespace_22;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_10;
using TMPro;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17
{
    
    internal static class InternalType_531
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static bool InternalField_2356 = false;

        [InitializeOnLoadMethod]
        private static void InternalMethod_2099()
        {
            ObjectChangeEvents.changesPublished -= InternalMethod_2103;
            ObjectChangeEvents.changesPublished += InternalMethod_2103;

            Undo.undoRedoPerformed -= InternalMethod_2101;
            Undo.undoRedoPerformed += InternalMethod_2101;

            InternalType_64.InternalEvent_1 -= InternalMethod_2102;
            InternalType_64.InternalEvent_1 += InternalMethod_2102;

            TMPro_EventManager.FONT_PROPERTY_EVENT.Add(InternalMethod_2100);

            SceneVisibilityManager.visibilityChanged += InternalMethod_609;
        }

        private static void InternalMethod_609()
        {
            InternalType_731.InternalMethod_3298();
        }

        public static event System.Action InternalEvent_5 = null;

        private static void InternalMethod_2100(bool InternalParameter_2424, Object InternalParameter_2425)
        {
            TMP_FontAsset InternalVar_1 = InternalParameter_2425 as TMP_FontAsset;
            if (InternalVar_1 == null)
            {
                return;
            }

            InternalMethod_1256(InternalVar_1.material.GetInstanceID(), InternalVar_1.material);
        }

        private static void InternalMethod_2101()
        {
            InternalField_2356 = true;
        }

        private static void InternalMethod_2102()
        {
            InternalField_2356 = false;
        }

        private static void InternalMethod_2103(ref ObjectChangeEventStream InternalParameter_2426)
        {
            for (int InternalVar_1 = 0; InternalVar_1 < InternalParameter_2426.length; InternalVar_1++)
            {
                ObjectChangeKind InternalVar_2 = InternalParameter_2426.GetEventType(InternalVar_1);


                switch (InternalVar_2)
                {
                    case ObjectChangeKind.ChangeGameObjectOrComponentProperties:
                        {
                            InternalParameter_2426.GetChangeGameObjectOrComponentPropertiesEvent(InternalVar_1, out ChangeGameObjectOrComponentPropertiesEventArgs InternalVar_3);
                            InternalMethod_2105(ref InternalVar_3);
                            break;
                        }
                    case ObjectChangeKind.ChangeAssetObjectProperties:
                        {
                            InternalParameter_2426.GetChangeAssetObjectPropertiesEvent(InternalVar_1, out ChangeAssetObjectPropertiesEventArgs InternalVar_3);
                            InternalMethod_2104(ref InternalVar_3);
                            break;
                        }
                    case ObjectChangeKind.ChangeGameObjectParent:
                        {
                            InternalParameter_2426.GetChangeGameObjectParentEvent(InternalVar_1, out ChangeGameObjectParentEventArgs InternalVar_3);
                            InternalMethod_2106(ref InternalVar_3);
                            break;
                        }
                }
            }

            InternalField_2356 = false;
        }

        private static void InternalMethod_2104(ref ChangeAssetObjectPropertiesEventArgs InternalParameter_2427)
        {
            Object InternalVar_1 = EditorUtility.InstanceIDToObject(InternalParameter_2427.instanceId);

            switch (InternalVar_1)
            {
                case Material material:
                    if (!material.shader.name.Contains("TextMeshPro"))
                    {
                        break;
                    }

                    InternalMethod_1256(InternalParameter_2427.instanceId, material);
                    break;

                case PlayerSettings playerSettings:
                    InternalEvent_5?.Invoke();
                    break;
            }
        }

        private static void InternalMethod_1256(int InternalParameter_3101, Material InternalParameter_3102)
        {
            if (!InternalType_325.InternalMethod_1954(InternalParameter_3101, InternalParameter_3102))
            {
                return;
            }

            NovaApplication.QueueEditorPlayerLoop();
        }

        private static void InternalMethod_2105(ref ChangeGameObjectOrComponentPropertiesEventArgs InternalParameter_2428)
        {
            Object InternalVar_1 = EditorUtility.InstanceIDToObject(InternalParameter_2428.instanceId);

            switch (InternalVar_1)
            {
                case GameObject gameObject:
                    {
                        if (!InternalType_44.InternalMethod_3259(gameObject.transform))
                        {
                            break;
                        }

                        if (gameObject.TryGetComponent(out UIBlock InternalVar_2))
                        {
                            InternalVar_2.GameObjectLayer = InternalVar_2.GameObjectLayer;
                        }
                        break;
                    }
                case Transform transform:
                    {
                        if (!InternalType_44.InternalMethod_3259(transform))
                        {
                            break;
                        }

                        if (transform.TryGetComponent(out UIBlock InternalVar_2))
                        {
                            if (InternalField_2356)
                            {
                                InternalVar_2.InternalMethod_104();
                            }

                            if (InternalVar_2.gameObject.activeInHierarchy)
                            {
                                InternalType_44.InternalMethod_3261(InternalVar_2);
                            }
                        }

                        break;
                    }
            }
        }

        private static void InternalMethod_2106(ref ChangeGameObjectParentEventArgs InternalParameter_2429)
        {
            Object InternalVar_1 = EditorUtility.InstanceIDToObject(InternalParameter_2429.instanceId);

            switch (InternalVar_1)
            {
                case Transform transform:
                    {
                        if (!InternalType_44.InternalMethod_3259(transform))
                        {
                            break;
                        }

                        if (InternalField_2356 && transform.TryGetComponent(out UIBlock InternalVar_2))
                        {
                            InternalVar_2.InternalMethod_103();
                        }

                        break;
                    }
            }
        }
    }
}

