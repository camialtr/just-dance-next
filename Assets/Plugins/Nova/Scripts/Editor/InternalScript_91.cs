// Copyright (c) Supernova Technologies LLC
using System.IO;
using UnityEditor;
using UnityEngine;

namespace Nova.InternalNamespace_17.InternalNamespace_18
{
    internal static class InternalType_554
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static string InternalField_2451 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static string InternalProperty_7
        {
            get
            {
                if (InternalField_2451 == null)
                {
                    string[] InternalVar_1 = AssetDatabase.FindAssets("UIBlock2DIcon t:texture2D");
                    if (InternalVar_1.Length == 0)
                    {
                        Debug.LogWarning("Failed to find Nova icons path");
                    }

                    InternalField_2451 = Path.GetDirectoryName(AssetDatabase.GUIDToAssetPath(InternalVar_1[0]));
                }

                return InternalField_2451;
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_2452 = "_DarkIcon.png";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const string InternalField_2453 = "_LightIcon.png";

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public const string InternalField_3453 = "Warning@2x";
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_3354 = EditorGUIUtility.TrIconContent(InternalField_3453);

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly GUIContent[][] InternalField_2454 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignLeft{InternalField_2453}")) { tooltip = "Left Aligned"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignCenterX{InternalField_2453}")) { tooltip = "X Center Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignRight{InternalField_2453}")) { tooltip = "Right Aligned" }
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignBottom{InternalField_2453}")) { tooltip = "Bottom Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignCenterY{InternalField_2453}")) { tooltip = "Y Center Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignTop{InternalField_2453}")) { tooltip = "Top Aligned" }
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignFront{InternalField_2453}")) { tooltip = "Front Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignCenterZ{InternalField_2453}")) { tooltip = "Z Center Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignBack{InternalField_2453}")) { tooltip = "Back Aligned" }
            }
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static readonly GUIContent[][] InternalField_2455 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignLeft{InternalField_2452}")) { tooltip = "Left Aligned"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignCenterX{InternalField_2452}")) { tooltip = "X Center Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignRight{InternalField_2452}")) { tooltip = "Right Aligned" }
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignBottom{InternalField_2452}")) { tooltip = "Bottom Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignCenterY{InternalField_2452}")) { tooltip = "Y Center Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignTop{InternalField_2452}")) { tooltip = "Top Aligned" }
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignFront{InternalField_2452}")) { tooltip = "Front Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignCenterZ{InternalField_2452}")) { tooltip = "Z Center Aligned" },
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/AlignBack{InternalField_2452}")) { tooltip = "Back Aligned" }
            }
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static GUIContent[][] InternalProperty_464 => EditorGUIUtility.isProSkin ? InternalField_2454 : InternalField_2455;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[][] InternalField_2456 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/LeftToRight{InternalField_2453}")) { tooltip = "Order Left to Right"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/RightToLeft{InternalField_2453}")) { tooltip = "Order Right to Left"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/TopToBottom{InternalField_2453}")) { tooltip = "Order Top to Bottom"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/BottomToTop{InternalField_2453}")) { tooltip = "Order Bottom to Top"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/FrontToBack{InternalField_2453}")) { tooltip = "Order Front to Back"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/BackToFront{InternalField_2453}")) { tooltip = "Order Back to Front"}
            }
        };


        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[][] InternalField_83 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent("align_horizontally_left")) { tooltip = "Left"},
                new GUIContent(EditorGUIUtility.TrIconContent("align_horizontally_center")) { tooltip = "Center" },
                new GUIContent(EditorGUIUtility.TrIconContent("align_horizontally_right")) { tooltip = "Right" }
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent("align_vertically_bottom")) { tooltip = "Bottom" },
                new GUIContent(EditorGUIUtility.TrIconContent("align_vertically_center")) { tooltip = "Middle" },
                new GUIContent(EditorGUIUtility.TrIconContent("align_vertically_top")) { tooltip = "Top" }
            }
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[][] InternalField_2457 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/LeftToRight{InternalField_2452}")) { tooltip = "Order Left to Right"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/RightToLeft{InternalField_2452}")) { tooltip = "Order Right to Left"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/TopToBottom{InternalField_2452}")) { tooltip = "Order Top to Bottom"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/BottomToTop{InternalField_2452}")) { tooltip = "Order Bottom to Top"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/FrontToBack{InternalField_2452}")) { tooltip = "Order Front to Back"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/BackToFront{InternalField_2452}")) { tooltip = "Order Back to Front"}
            }
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static GUIContent[][] InternalProperty_465 => EditorGUIUtility.isProSkin ? InternalField_2456 : InternalField_2457;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[][] InternalField_2458 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ExpandX{InternalField_2452}")) { tooltip = "Expand to Parent"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ShrinkX{InternalField_2452}")) { tooltip = "Shrink to Children"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ExpandY{InternalField_2452}")) { tooltip = "Expand to Parent"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ShrinkY{InternalField_2452}")) { tooltip = "Shrink to Children"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ExpandZ{InternalField_2452}")) { tooltip = "Expand to Parent"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ShrinkZ{InternalField_2452}")) { tooltip = "Shrink to Children"}
            },
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[][] InternalField_2459 = new GUIContent[][]
        {
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ExpandX{InternalField_2453}")) { tooltip = "Expand to Parent"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ShrinkX{InternalField_2453}")) { tooltip = "Shrink to Children"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ExpandY{InternalField_2453}")) { tooltip = "Expand to Parent"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ShrinkY{InternalField_2453}")) { tooltip = "Shrink to Children"}
            },
            new GUIContent[]
            {
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ExpandZ{InternalField_2453}")) { tooltip = "Expand to Parent"},
                new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/ShrinkZ{InternalField_2453}")) { tooltip = "Shrink to Children"}
            }
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static GUIContent[][] InternalProperty_466 => EditorGUIUtility.isProSkin ? InternalField_2459 : InternalField_2458;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[] InternalField_2460 = new GUIContent[]
        {
            EditorGUIUtility.TrTextContent("V", "Value Length"),
            EditorGUIUtility.TrTextContent("%", "Percent Length")
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[] InternalField_2461 = new GUIContent[]
        {
            EditorGUIUtility.TrTextContent("X", "Width controls Height and Depth"),
            EditorGUIUtility.TrTextContent("Y", "Height controls Width and Depth"),
            EditorGUIUtility.TrTextContent("Z", "Depth controls Width and Height")
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[] InternalField_2462 = new GUIContent[]
        {
            EditorGUIUtility.TrTextContent("X", "Width controls Height"),
            EditorGUIUtility.TrTextContent("Y", "Height controls Width")
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[] InternalField_2463 = new GUIContent[]
        {
            EditorGUIUtility.TrTextContent("X", "Position Horizontally"),
            EditorGUIUtility.TrTextContent("Y", "Position Vertically"),
            EditorGUIUtility.TrTextContent("Z", "Position in Z")
        };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2464 = EditorGUIUtility.TrTextContent("X");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2465 = EditorGUIUtility.TrTextContent("Y");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2466 = EditorGUIUtility.TrTextContent("Z");

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2467 = EditorGUIUtility.TrTextContent("Left");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2468 = EditorGUIUtility.TrTextContent("Right");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2469 = EditorGUIUtility.TrTextContent("Top");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2470 = EditorGUIUtility.TrTextContent("Bottom");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2471 = EditorGUIUtility.TrTextContent("Front");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2472 = EditorGUIUtility.TrTextContent("Back");

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent[] InternalField_2473 = new GUIContent[] { InternalField_2464, InternalField_2465, InternalField_2466 };

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2474 = EditorGUIUtility.TrTextContent("Min");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2475 = EditorGUIUtility.TrTextContent("Max");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_2476 = EditorGUIUtility.TrTextContent("Min-Max");
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_3627 = EditorGUIUtility.TrTextContent(" ", "Opacity");

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        public static readonly GUIContent InternalField_3642 = EditorGUIUtility.TrIconContent($"{InternalProperty_7}/NovaLogo.png");

        public class InternalType_555
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private const string InternalField_1121 = "The lighting models to include in builds. Including lighting models increases both build time and the size of the final build due to the number of shader variants. Only select models that you know you use in the final build.";

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2477 = EditorGUIUtility.TrTextContent("Log Flags", "Enables or disables warnings that may be logged by Nova.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_382 = EditorGUIUtility.TrTextContent("Packed images", "Global toggle for packed images, which reduce the number of draw calls by batching images with the same dimensions, format, and mip count.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2479 = EditorGUIUtility.TrTextContent("Super Sample Text", "Improves quality of text (especially in VR).");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2480 = EditorGUIUtility.TrTextContent("Edge Soften Width", "The width (in pixels) of the softening for edges (block edges, clip mask edges, etc.).");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_379 = EditorGUIUtility.TrTextContent("Packed Image Copy Mode", "Specifies how to copy packed images into the texture array if the source texture is compressed using a block based format. Certain older versions of the Nvidia OpenGL driver may crash if a certain mip level of the source texture is not a multiple of the block size. Setting copy mode to \"Skip\" will skip over these mip levels.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2482 = EditorGUIUtility.TrTextContent("UIBlock3D Corner Divisions", "The number of divisions for a UIBlock3D's corner radius. A larger value has a greater performance cost but leads to a higher quality mesh.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2483 = EditorGUIUtility.TrTextContent("UIBlock3D Edge Divisions", "The number of divisions for a UIBlock3D's edge radius. A larger value has a greater performance cost but leads to a higher quality mesh.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2484 = EditorGUIUtility.TrTextContent("Included Lighting Models", InternalField_1121);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1099 = EditorGUIUtility.TrTextContent("UIBlock2D", InternalField_1121);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1098 = EditorGUIUtility.TrTextContent("UIBlock3D", InternalField_1121);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1097 = EditorGUIUtility.TrTextContent("TextBlock", InternalField_1121);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_372 = EditorGUIUtility.TrTextContent("Click Frame Threshold", "The number of frames that must separate a \"Press\" and \"Release\" Gesture in order to trigger a Click. For low-accuracy input devices (e.g. VR hand tracking), a higher value (such as 3) might be required to reduce noise. For high-accuracy input devices (e.g. mouse and touch), 1 should be sufficient.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2485 = EditorGUIUtility.TrTextContent("Edge Snapping", "Enables or disables edge detection and snapping for all Nova editor tools (e.g. UIBlock Tool and Padding/Margin Tool).");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1013 = EditorGUIUtility.TrTextContent("Hierarchy Gizmos", "Enables or disables outlining every UIBlock in the selection hierarchy. Only applicable while scene Gizmos are enabled.");
        }

        public static class InternalType_556
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_2486 = new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/3DToggle{InternalField_2453}")) { tooltip = "Show All 3D Properties." };
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_2487 = new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/3DToggle{InternalField_2452}")) { tooltip = "Show All 3D Properties." };

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIContent InternalProperty_467 => EditorGUIUtility.isProSkin ? InternalField_2486 : InternalField_2487;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2488 = EditorGUIUtility.TrTextContent("Preview", "An Edit-Mode-Only utility for UI Block scene and prefab roots to preview percent-based properties when detached from a parent UI Block.");
        }

        public static class InternalType_557
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2086 = EditorGUIUtility.TrTextContent("Enabled", "Enable to select an Axis.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2091 = EditorGUIUtility.TrTextContent("Primary Axis", "Position all child elements sequentially along this axis. \n\nWhen applicable, content scrolls along this axis.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2489 = EditorGUIUtility.TrTextContent("Spacing", "The space to insert between children.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2490 = EditorGUIUtility.TrTextContent("Auto", "Automatically adjust spacing so that the child UI Blocks fill the available space in the parent container.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_464 = EditorGUIUtility.TrTextContent("Auto", "Auto spacing cannot be used with a ListView or GridView.\n\nAutomatically adjust spacing so that the child UI Blocks fill the available space in the parent container.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2491 = EditorGUIUtility.TrTextContent("Axis", "The axis along which children are positioned. Must be \"Enabled\" to configure.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2492 = EditorGUIUtility.TrTextContent("Alignment", "Alignment of the children.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2493 = EditorGUIUtility.TrTextContent("Order", "The order of the children.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2494 = EditorGUIUtility.TrTextContent("Offset", "An offset applied to all children.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2090 = EditorGUIUtility.TrTextContent("Cross Axis", "Create a 2D layout which will first position as many children as will fit along the cross axis before wrapping to the primary axis.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2605 = EditorGUIUtility.TrTextContent("Cross Axis", "Cross Axis cannot be used with a ListView or GridView.\n\nCreate a 2D layout which will first position as many children as will fit along the cross axis before wrapping to the primary axis.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3711 = EditorGUIUtility.TrTextContent("Expand to Grid", "Makes the cross axis size of \"Expanded\" elements as well as \"Auto\" spacing more uniform, so the remaining overflow items better align to implicit grid cells. \n\nIf the configured minimum size of a given \"Expanded\" child is larger than the configured minimum size of one or more \"Expanded\" siblings, the child will span across multiple grid cells.\n\nDoes not impact the size of elements not set to \"Expand\".");
        }

        public static class InternalType_558
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2495 = EditorGUIUtility.TrTextContent("Color", "The color of the body.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2496 = EditorGUIUtility.TrTextContent("Corner Radius", "The radius of the corners of the body, border, and shadow.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2497 = EditorGUIUtility.TrTextContent("Soften Edges", "In certain situations, like when rendering a texture that has transparency which handles softening edges, having Nova add additional edge softening may not be desired.");
        }

        public static class InternalType_559
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2498 = EditorGUIUtility.TrTextContent("Color", "The color of the UI Block.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2499 = EditorGUIUtility.TrTextContent("Corner Radius", "The radius of the front and back face corners.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2500 = EditorGUIUtility.TrTextContent("Edge Radius", "The radius of the front and back face edges.");
        }

        public static class InternalType_560
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2501 = EditorGUIUtility.TrTextContent("Visible", "The visibility of all rendered visuals on this UI Block.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2502 = EditorGUIUtility.TrTextContent("Z-Index", "Overrides the default render order for coplanar, 2D elements within a Sort Group. Higher values are drawn on top.");
        }

        public static class InternalType_561
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2503 = EditorGUIUtility.TrTextContent("Size", "The size of the UI Block.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2504 = EditorGUIUtility.TrTextContent("Auto Size", "Make size adapt to size of parent or children.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2505 = EditorGUIUtility.TrTextContent("Rotate Size", "Specifies whether or not to include the UI Block's rotation when calculating size.");
        }

        public static class InternalType_562
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2506 = EditorGUIUtility.TrTextContent("Position", "The position of the UI Block.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2507 = EditorGUIUtility.TrTextContent("Alignment", "The alignment relative to parent's padded size.");
        }

        public static class InternalType_563
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_715 = EditorGUIUtility.TrTextContent("Visuals", "The set of visual fields.");
        }

        public static class InternalType_743
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3454 = EditorGUIUtility.TrTextContent("Obstruct Drags", "When true, drag gestures will not be routed to content behind the attached UIBlock.\nWhen false, content behind the attached UIBlock can receive drag gestures if it is \"draggable\" in a direction this component is not.\nDoes not impact the \"draggable\" state of this component.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3455 = EditorGUIUtility.TrTextContent("Drag Threshold", "The threshold that must be surpassed to initiate a drag event.\n\nThis threshold is generally used for high precision input devices, E.g. mouse, touchscreen, VR controller, and most other ray based input.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3456 = EditorGUIUtility.TrTextContent("Low Accuracy Drag Threshold", "The threshold that must be surpassed to initiate a drag event.\n\nThis \"Low Accuracy\" threshold is generally used for noisier (i.e. less physically stable) input devices, E.g. VR handtracking and other sphere collider based input.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3457 = EditorGUIUtility.TrTextContent("Click Behavior", "Determines when this component should trigger click events.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3458 = EditorGUIUtility.TrTextContent("Navigable", "Is this component navigable?");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3459 = EditorGUIUtility.TrTextContent("Navigation", "Defines a navigation target per axis-aligned direction.");

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3460 = EditorGUIUtility.TrTextContent("On Select", "Determines how this component should handle navigation \"Select\" events.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3461 = EditorGUIUtility.TrTextContent("Auto Select", "Determines if this component should automatically be selected whenever it's navigated to.\n\nIf \"On Select\" is set to \"Scope Navigation\", setting this to True will effectively allow navigation moves to pass through the attached UIBlock onto the navigable descendant closest to the navigation source.");

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_3462 = EditorGUIUtility.TrIconContent("scenevis_visible_hover", "Hide Navigation Graph");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_3463 = EditorGUIUtility.TrIconContent("scenevis_hidden_hover", "Show Navigation Graph");

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_3464 = EditorGUIUtility.TrIconContent("scenepicking_pickable_hover", "Filter Graph to Selection");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_3465 = EditorGUIUtility.TrIconContent("scenepicking_notpickable_hover", "Show Full Graph");

            public static GUIContent InternalMethod_3435(bool InternalParameter_3214)
            {
                return InternalParameter_3214 ? InternalField_3465 : InternalField_3464;
            }

            public static GUIContent InternalMethod_3436(bool InternalParameter_3215)
            {
               return InternalParameter_3215 ? InternalField_3462 : InternalField_3463;
            }
        }

        public static class InternalType_744
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3466 = EditorGUIUtility.TrTextContent("Draggable", "Acts as a bit - mask indicating which axes can trigger drag events once a \"drag threshold\" is surpassed.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3785 = EditorGUIUtility.TrTextContent("Gesture Space", "The coordinate space used to track gesture positions across frames.\n\nIf the local position, local rotation, or local scale of the UIBlock root may change while a gesture on this Interactable is active, use \"World\", otherwise \"Root\" is recommended.");
        }

        public static class InternalType_745
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3467 = EditorGUIUtility.TrTextContent("Overscroll Effect", "The behavior applied when there's no more content to scroll in the scrolling direction");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3468 = EditorGUIUtility.TrTextContent("Drag Scrolling", "Allow Interactions.Point drag events to trigger a scroll.\n\nE.g. Dragging on a touch screen.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3469 = EditorGUIUtility.TrTextContent("Vector Scrolling", "Allow Interactions.Scroll vector events to trigger a scroll.\n\nE.g. Scroll wheel on a mouse.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3470 = EditorGUIUtility.TrTextContent("Vector Scroll Multiplier", "The speed multiplier for vector scrolling");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3471 = EditorGUIUtility.TrTextContent("Draggable Scrollbar", "Indicates whether or not the Scroller should handle drag events on the Scrollbar Visual automatically.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3472 = EditorGUIUtility.TrTextContent("Scrollbar Visual", "The visual representing the scroll position of content relative to the viewport. The Scroller component will adjust this visual's size/position along the scrolling axis");
        }

        public static class InternalType_746
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3473 = EditorGUIUtility.TrTextContent(nameof(Nova.NavLink.Type), "The type of navigation to perform in this direction.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3474 = EditorGUIUtility.TrTextContent(nameof(Nova.NavLink.Target), "The Interactable or Scroller to navigate to when \"Type\" is set to \"Manual\".");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3475 = EditorGUIUtility.TrTextContent(nameof(Nova.NavLink.Fallback), "Designates the fallback behavior in the event a navigation target isn't found or is not configured to be navigable.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3476 = EditorGUIUtility.TrIconContent(InternalField_3453, "\"Target\" not configured to be navigable. Will result in \"Fallback\" behavior.");
        }

        public static class InternalType_747
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_3477 = new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/3DToggle{InternalField_2453}")) { tooltip = "Show navigation directions for Z axis." };
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static readonly GUIContent InternalField_3478 = new GUIContent(EditorGUIUtility.TrIconContent($"{InternalProperty_7}/3DToggle{InternalField_2452}")) { tooltip = "Show navigation directions for Z axis." };

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static GUIContent InternalProperty_1091 => EditorGUIUtility.isProSkin ? InternalField_3477 : InternalField_3478;
        }

        public static class InternalType_564
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2509 = EditorGUIUtility.TrTextContent("Tint", "The tint color to apply to this block and its descendants.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2510 = EditorGUIUtility.TrTextContent("Clip", "Enables or disables clipping. Can be used to make the clip mask exclusively apply a tint.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2511 = EditorGUIUtility.TrTextContent("Mask", "The texture to use as a mask, if \"Clip\" is enabled.");
        }

        public static class InternalType_565
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private const string InternalField_1436 = "Render Queue";
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private const string InternalField_1431 = "Render Over Opaque Geometry";
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private const string InternalField_1430 = "This value is inherited from the Screen Space root.";

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2512 = EditorGUIUtility.TrTextContent("Sorting Order", "The sorting order of this hierarchy relative to other coplanar Nova content. Higher values render on top.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2513 = EditorGUIUtility.TrTextContent(InternalField_1436, "The value that will be assigned to the material's render queue for the hierarchy.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1429 = EditorGUIUtility.TrTextContent(InternalField_1436, InternalField_1430);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_207 = EditorGUIUtility.TrTextContent(InternalField_1431, "Whether or not the content in the sort group should render over geometry rendered in the opaque render queue. This is useful for rendering in screen space.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1428 = EditorGUIUtility.TrTextContent(InternalField_1431, InternalField_1430);
        }

        public static class InternalType_65
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1433 = EditorGUIUtility.TrTextContent("Target Camera", "The target camera used to render the Nova content.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2268 = EditorGUIUtility.TrTextContent("Additional Cameras", "Additional cameras that the ScreenSpace content will be rendered to.\nNOTE: The content will still be positioned and size based on the Target Camera, it will simply also render to these additional cameras.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1432 = EditorGUIUtility.TrTextContent("Fill Mode", $"The mode used to render the content:\n-{nameof(Nova.ScreenSpace.FillMode.FixedWidth)}: Maintains the {nameof(Nova.ScreenSpace.ReferenceResolution)} width on the root UIBlock, adjusting the height to match the camera's aspect ratio.\n-{nameof(Nova.ScreenSpace.FillMode.FixedHeight)}: Maintains the {nameof(Nova.ScreenSpace.ReferenceResolution)} height on the root UIBlock, adjusting the width to match the camera's aspect ratio.\n-{nameof(Nova.ScreenSpace.FillMode.MatchCameraResolution)}: Sets the root UIBlock's size to match the pixel-dimensions of the camera.\n-{nameof(Nova.ScreenSpace.FillMode.Manual)}: Does not modify the size or scale of the UIBlock. Useful if a custom resize behavior is desired.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_143 = EditorGUIUtility.TrTextContent("Reference Resolution", "The resolution to use as a reference when resizing the root UIBlock to match the camera's aspect ratio.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_448 = EditorGUIUtility.TrTextContent("Plane Distance", "The distance in front of the camera at which to render the Nova content.");
        }

        public static class InternalType_566
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2514 = EditorGUIUtility.TrTextContent("Padding", "The padding of the UI Block. Expands inward.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2515 = EditorGUIUtility.TrTextContent("Margin", "The margin of the UI Block. Expands outward.");
        }

        public static class InternalType_567
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public const string InternalField_3355 = "Lit surfaces are currently only supported in the built-in render pipeline.";
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2516 = EditorGUIUtility.TrTextContent("Surface", "The appearance of this UI Block's mesh surface under scene lighting.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2517 = EditorGUIUtility.TrTextContent("Lighting Model", "The lighting model to apply to this UI Block's mesh surface.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2518 = EditorGUIUtility.TrTextContent("Shadow Casting", "Specifies if the UI Block should cast shadows.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2519 = EditorGUIUtility.TrTextContent("Receive Shadows", "Specifies whether or not the UI Block should receive shadows. NOTE: Only opaque blocks can receive shadows.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2520 = EditorGUIUtility.TrTextContent("Specular", "Specular power.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2521 = EditorGUIUtility.TrTextContent("Gloss", "Specular intensity.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2522 = EditorGUIUtility.TrTextContent("Metallic", "How metallic the surface appears.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2523 = EditorGUIUtility.TrTextContent("Smoothness", "How smooth the surface appears.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2524 = EditorGUIUtility.TrTextContent("Specular Color", "The color of the specular reflections.");
        }

        public static class InternalType_207
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3395 = EditorGUIUtility.TrTextContent("Radial Fill", "Enable radial fill.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3396 = EditorGUIUtility.TrTextContent("Center", "The center position/origin of the radial cutout.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3397 = EditorGUIUtility.TrTextContent("Rotation", "The angle (in degrees from the positive x-axis) that serves as the basis rotation from which Fill Angle will apply.\n- Positive => counter-clockwise\n- Negative => clockwise");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_3398 = EditorGUIUtility.TrTextContent("Fill Angle", "The arc angle (in degrees) of the fill.\n- Positive => counter-clockwise\n- Negative => clockwise");
        }

        public static class InternalType_568
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2525 = EditorGUIUtility.TrTextContent("Gradient", "Enable Gradient.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2526 = EditorGUIUtility.TrTextContent(string.Empty, "Gradient color.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2527 = EditorGUIUtility.TrTextContent("Center", "The center position of the gradient.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2528 = EditorGUIUtility.TrTextContent("Radius", "The radii along the gradient's X and Y axes. Determines the gradient's size.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2529 = EditorGUIUtility.TrTextContent("Rotation", "The counter-clockwise rotation of the gradient (in degrees) around its center.");
        }

        public static class InternalType_569
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2530 = EditorGUIUtility.TrTextContent("Image", "The image to render in the body of this UI Block.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2531 = EditorGUIUtility.TrTextContent("Mode", "Specifies how the Nova Engine should store and attempt to batch the image.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2532 = EditorGUIUtility.TrTextContent("Scale Mode", "Specifies how to render the image based on the aspect ratio of the image and the UI Block.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2533 = EditorGUIUtility.TrTextContent("Center", "The center position of the image in UV space, where UVs go from (-1, -1) in the bottom-left to (1, 1) in the top-right.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2534 = EditorGUIUtility.TrTextContent("Scale", "How much to scale the image in UV space, where UVs go from (-1, -1) in the bottom-left to (1, 1) in the top-right.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_1333 = EditorGUIUtility.TrTextContent("Pixels Per Unit Multiplier", "Determines how many pixels from the target image fit into a 1x1 square in the UIBlock2D's local space.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent[] InternalField_2535 = new GUIContent[] { EditorGUIUtility.TrTextContent("T", "Texture"), EditorGUIUtility.TrTextContent("S", "Sprite") };
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public const string InternalField_3635 = "\"Sliced\" Scale Mode isn't compatible with \"Texture\" images. Change the Image Type to \"Sprite\" to used \"Sliced\" Scale Mode.";
        }

        public static class InternalType_570
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2536 = EditorGUIUtility.TrTextContent("Color", "The color of the shadow. Darker colors create a more shadow-like effect, whereas brighter colors create a more glow-like effect.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2537 = EditorGUIUtility.TrTextContent("Direction", "The direction the shadow will expand.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2538 = EditorGUIUtility.TrTextContent("Width", "The width of the shadow, before blur is applied.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2539 = EditorGUIUtility.TrTextContent("Blur", "The blur of the shadow. A larger blur leads to a softer effect, whereas a smaller blur leads to a sharper effect.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2540 = EditorGUIUtility.TrTextContent("Offset", "The offset of the shadow.");
        }

        public static class InternalType_571
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2541 = EditorGUIUtility.TrTextContent("Color", "The color of the border.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2542 = EditorGUIUtility.TrTextContent("Width", "The width of the border.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2543 = EditorGUIUtility.TrTextContent("Direction", "The direction the border will expand.");
        }

        public static class InternalType_572
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2544 = EditorGUIUtility.TrTextContent("Align", "Sets the alignment on the attached Text Mesh Pro component.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2545 = EditorGUIUtility.TrTextContent("Text", "Sets the text on the attached Text Mesh Pro component.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2546 = EditorGUIUtility.TrTextContent("Color", "Sets the vertex color on the attached Text Mesh Pro component.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2547 = EditorGUIUtility.TrTextContent("Font", "Sets the Font Asset on the attached Text Mesh Pro component.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2548 = EditorGUIUtility.TrTextContent("Font Size", "Sets the font size on the attached Text Mesh Pro component.");
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly GUIContent InternalField_2549 = new GUIContent(EditorGUIUtility.TrIconContent("d_console.infoicon.inactive.sml")) { tooltip = "[Text] and its expanded properties write directly to the attached Text Mesh Pro object. They are not controlled by this Text Block at runtime." };
        }
    }
}

