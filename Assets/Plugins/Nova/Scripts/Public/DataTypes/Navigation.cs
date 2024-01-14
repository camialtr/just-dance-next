// Copyright (c) Supernova Technologies LLC

using Nova.Compat;
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_2;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Collections.Generic;
using UnityEngine;
using static Nova.Interaction;

namespace Nova
{
    /// <summary>
    /// A callback to invoke whenever navigation focus for a particular <paramref name="controlID"/> moves to a new <see cref="UIBlock"/>, <paramref name="focused"/>. 
    /// </summary>
    /// <param name="controlID">The unique identifier of the input control whose navigation focus is now set on <paramref name="focused"/>.</param>
    /// <param name="focused">The <see cref="UIBlock"/> which will now receive subsequent <see cref="Navigate.OnSelect"/> events. Can be <c>null</c>.</param>
    public delegate void NavigationFocusChangedCallback(uint controlID, UIBlock focused);

    /// <summary>
    /// The static access point to provide input navigation and selection events.
    /// </summary>
    /// <seealso cref="Navigate.OnMoveTo"/>
    /// <seealso cref="Navigate.OnMoveFrom"/>
    /// <seealso cref="Navigate.OnDirection"/>
    /// <seealso cref="Navigate.OnSelect"/>
    /// <seealso cref="Navigate.OnDeselect"/>
    public static class Navigation
    {
        /// <summary>
        /// Event fired after the navigation queue has been processed, if a new <see cref="UIBlock"/> 
        /// with an attached <see cref="GestureRecognizer"/> component receives navigation focus
        /// from a particular controlID.
        /// </summary>
        public static event NavigationFocusChangedCallback OnNavigationFocusChanged = null;

        /// <summary>
        /// Moves navigation focus to <paramref name="uiBlock"/>.
        /// </summary>
        /// <param name="uiBlock">The <see cref="UIBlock"/> used as the starting point for subsequent navigation events.</param>
        /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.</param>
        /// <param name="userData">Any additional data to pass along to the receiver of the current interaction. See <see cref="Update.UserData"/>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <exception cref="System.ArgumentException">If <paramref name="controlID"/> is out of range or if <paramref name="uiBlock"/> is not navigable.</exception>
        public static void Focus(UIBlock uiBlock, uint controlID = 0, object userData = null, int layerMask = AllLayers)
        {
            if (controlID < 0 || controlID >= InternalType_89.InternalField_2940)
            {
                throw new System.ArgumentException($"Invalid Control ID [{controlID}]. Expected within range [0, {InternalType_89.InternalField_2940}).");
            }

            UIBlock InternalVar_1 = InternalType_757<UIBlock>.InternalMethod_3568(controlID);

            if (InternalVar_1 == uiBlock)
            {
                return;
            }

            Ray InternalVar_2 = InternalMethod_2947(InternalVar_1, uiBlock);

            if (uiBlock != null)
            {
                if ((layerMask & (1 << uiBlock.gameObject.layer)) == 0)
                {
                    throw new System.ArgumentException($"{uiBlock.name} not on focusable layer provided by {nameof(layerMask)}.");
                }

                if (!uiBlock.TryGetComponent(out GestureRecognizer InternalVar_3))
                {
                    throw new System.ArgumentException($"{uiBlock.name} not navigable. Navigation starting point must have an {nameof(Interactable)} or {nameof(Scroller)} component attached, enabled, and configured to be navigable.");
                }

                if (!InternalVar_3.enabled)
                {
                    throw new System.ArgumentException($"{uiBlock.name} not navigable. Attached {InternalVar_3.GetType().Name} must be enabled and configured to be navigable.");
                }

                if (!InternalVar_3.Navigable)
                {
                    throw new System.ArgumentException($"{uiBlock.name} not navigable. Attached {InternalVar_3.GetType().Name} must have {nameof(GestureRecognizer.Navigable)} set to \"True\".");
                }
            }

            InternalMethod_2689(InternalProperty_1085, InternalType_738.InternalMethod_2888(InternalVar_1, uiBlock, new Update(InternalVar_2, controlID, userData), layerMask, InternalParameter_3134: uiBlock != null));
        }

        /// <summary>
        /// Queues an attempt to move navigation focus to the next navigable <see cref="UIBlock"/> in the approximate local
        /// space direction to be processed at the start of the next frame, after the Nova Engine 
        /// update has run for the current frame. 
        /// </summary>
        /// <param name="direction">The direction to navigate in the local space of the current focused element.</param>
        /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.</param>
        /// <param name="userData">Any additional data to pass along to the receiver of the current interaction. See <see cref="Update.UserData"/>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <exception cref="System.ArgumentException">If <paramref name="controlID"/> is out of range.</exception>
        /// <exception cref="System.InvalidOperationException">
        /// If <see cref="Focus(UIBlock, uint, object, int)"/> has not been called for the given <paramref name="controlID"/>.
        /// </exception>
        public static void Move(Vector3 direction, uint controlID = 0, object userData = null, int layerMask = AllLayers)
        {
            if (controlID < 0 || controlID >= InternalType_89.InternalField_2940)
            {
                throw new System.ArgumentException($"Invalid Control ID [{controlID}]. Expected within range [0, {InternalType_89.InternalField_2940})");
            }

            UIBlock InternalVar_1 = InternalType_757<UIBlock>.InternalMethod_3568(controlID);

            if (InternalVar_1 == null)
            {
                throw new System.InvalidOperationException($"Unable to move navigation focus. Must call {nameof(Focus)} with a navigable {nameof(UIBlock)} and matching {nameof(controlID)} before any calls to {nameof(Move)}.");
            }

            direction.Normalize();

            GestureRecognizer InternalVar_2 = InternalVar_1.InternalProperty_23.InternalProperty_1150 as GestureRecognizer;
            bool InternalVar_3 = InternalVar_2 != null && InternalVar_2.Navigation.GetLink(direction).Fallback == NavLinkFallback.NavigateOutsideScope;

            int InternalVar_4 = InternalType_757<UIBlock>.InternalMethod_3620(controlID);

            if (!InternalVar_3)
            {
                InternalVar_4 = Mathf.Min(1, InternalVar_4);
            }

            InternalType_5 InternalVar_5 = null;
            InternalType_764 InternalVar_6 = InternalType_764.InternalField_1157;

            if (InternalVar_4 == 0)
            {
                InternalVar_6 = InternalType_757<UIBlock>.InternalMethod_3613(InternalVar_1, null, direction, layerMask, out InternalVar_5);
            }

            for (int InternalVar_7 = 0; InternalVar_7 < InternalVar_4; ++InternalVar_7)
            {
                UIBlock InternalVar_8 = InternalType_757<UIBlock>.InternalMethod_3571(controlID, InternalVar_7);
                bool InternalVar_9 = InternalVar_8 != null;
                bool InternalVar_10 = InternalVar_9 && InternalVar_8.InternalProperty_23.InternalProperty_1152;

                if (InternalVar_10)
                {
                    Update InternalVar_11 = new Update(InternalType_757<UIBlock>.InternalMethod_3583(direction, InternalVar_8, InternalParameter_3305: true), controlID, userData);
                    InternalVar_8.InternalMethod_91(Navigate.InternalMethod_461(InternalVar_11, InternalVar_8, direction));
                    return;
                }

                InternalVar_6 = InternalType_757<UIBlock>.InternalMethod_3613(InternalVar_1, InternalVar_8, direction, layerMask, out InternalVar_5);

                if (InternalVar_6 != InternalType_764.InternalField_1157)
                {
                    InternalType_5 InternalVar_11 = InternalVar_5 != null ? InternalVar_5 : InternalVar_1;
                    InternalType_757<UIBlock>.InternalMethod_3637(InternalVar_11, controlID, InternalVar_7);

                    break;
                }

                if (!InternalVar_9)
                {
                    continue;
                }

                if ((InternalVar_8.InternalProperty_23.InternalProperty_1150 is GestureRecognizer gr) && gr.Navigation.GetLink(direction).Fallback != NavLinkFallback.NavigateOutsideScope)
                {
                    break;
                }
            }

            InternalType_738 InternalVar_12 = InternalVar_6 == InternalType_764.InternalField_1557 ? InternalType_738.InternalMethod_2801(InternalVar_1, InternalVar_5 as UIBlock, new Update(InternalType_757<UIBlock>.InternalMethod_3583(direction, InternalVar_1), controlID, userData), direction, layerMask) :
                                                            InternalType_738.InternalMethod_2815(controlID, direction, userData, layerMask);

            InternalProperty_1082.Add(InternalVar_12);
        }

        /// <summary>
        /// Selects the currently focused <see cref="UIBlock"/>.
        /// </summary>
        /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.</param>
        /// <param name="userData">Any additional data to pass along to the receiver of the current interaction. See <see cref="Update.UserData"/>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <exception cref="System.ArgumentException">If <paramref name="controlID"/> is out of range.</exception>
        public static void Select(uint controlID = 0, object userData = null, int layerMask = AllLayers)
        {
            if (controlID < 0 || controlID >= InternalType_89.InternalField_2940)
            {
                throw new System.ArgumentException($"Invalid Control ID [{controlID}]. Expected within range [0, {InternalType_89.InternalField_2940})");
            }

            UIBlock InternalVar_1 = InternalType_757<UIBlock>.InternalMethod_3568(controlID);

            if (InternalVar_1 == null)
            {
                return;
            }

            GestureRecognizer InternalVar_2 = InternalVar_1.InternalProperty_23.InternalProperty_1150 as GestureRecognizer;

            if (InternalVar_2 == null)
            {
                return;
            }

            if ((layerMask & (1 << InternalVar_1.gameObject.layer)) == 0)
            {
                Debug.LogWarning($"Unable to select. Focused {nameof(UIBlock)}, {InternalVar_1.name}, not on selectable layer provided by {nameof(layerMask)}.", InternalVar_1);
                return;
            }

            bool InternalVar_3 = InternalType_757<UIBlock>.InternalMethod_3570(controlID) != InternalVar_1;

            if (!InternalVar_3)
            {
                return;
            }

            Ray InternalVar_4 = new Ray(InternalVar_1.transform.position, -InternalVar_1.transform.forward);
            Update InternalVar_5 = new Update(InternalVar_4, controlID, userData);

            switch (InternalVar_2.OnSelect)
            {
                case SelectBehavior.Click:
                    {
                        InternalVar_1.InternalMethod_91(Gesture.InternalMethod_3226(InternalVar_5, InternalVar_1));
                        break;
                    }
                case SelectBehavior.FireEvents:
                    {
                        InternalType_757<UIBlock>.InternalMethod_3572(controlID, InternalVar_1, layerMask);
                        InternalVar_1.InternalMethod_91(Navigate.InternalMethod_460(InternalVar_5, InternalVar_1));
                        break;
                    }
                case SelectBehavior.ScopeNavigation:
                    {
                        InternalType_757<UIBlock>.InternalMethod_3572(controlID, InternalVar_1, layerMask);
                        InternalVar_1.InternalMethod_91(Navigate.InternalMethod_460(InternalVar_5, InternalVar_1));

                        if (InternalVar_1.ChildCount == 0)
                        {
                            break;
                        }

                        InternalProperty_1082.Add(InternalType_738.InternalMethod_2796(controlID, InternalVar_1, userData, layerMask));

                        break;
                    }
            }
        }

        /// <summary>
        /// Deselects the currently selected <see cref="UIBlock"/>.
        /// </summary>
        /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.</param>
        /// <param name="userData">Any additional data to pass along to the receiver of the current interaction. See <see cref="Update.UserData"/>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <exception cref="System.ArgumentException">If <paramref name="controlID"/> is out of range.</exception>
        public static void Deselect(uint controlID = 0, object userData = null, int layerMask = AllLayers)
        {
            if (controlID < 0 || controlID >= InternalType_89.InternalField_2940)
            {
                throw new System.ArgumentException($"Invalid Control ID [{controlID}]. Expected within range [0, {InternalType_89.InternalField_2940})");
            }

            UIBlock InternalVar_1 = InternalType_757<UIBlock>.InternalMethod_3568(controlID);
            UIBlock InternalVar_2 = InternalType_757<UIBlock>.InternalMethod_3574(controlID);

            if (InternalVar_2 != null)
            {
                Ray InternalVar_3 = InternalMethod_2947(InternalVar_1, InternalVar_2);

                Update InternalVar_4 = new Update(InternalVar_3, controlID, userData);

                InternalMethod_2689(InternalProperty_1085, InternalType_738.InternalMethod_2888(InternalVar_1, InternalVar_2, InternalVar_4, layerMask));

                InternalVar_2.InternalMethod_91(Navigate.InternalMethod_2058(InternalVar_4, InternalVar_2));
            }
        }

        /// <summary>
        /// Retrieves the <see cref="UIBlock"/> which was most recently navigated to from the provided <paramref name="controlID"/>.
        /// </summary>
        /// <param name="controlID">The unique identifier of the input control.</param>
        /// <param name="focused">The <see cref="UIBlock"/> most recently navigated to with the given <paramref name="controlID"/>.</param>
        /// <returns>If a navigated <see cref="UIBlock"/> is found and actively navigable, returns <c>true</c>. If the <see cref="UIBlock"/> was not found or is no longer navigable, returns <c>false</c>.</returns>
        public static bool TryGetFocusedUIBlock(uint controlID, out UIBlock focused)
        {
            focused = null;
            if (controlID < 0 || controlID >= InternalType_89.InternalField_2940)
            {
                return false;
            }

            focused = InternalType_757<UIBlock>.InternalMethod_3568(controlID);

            if (focused != null && focused.InternalProperty_23.InternalProperty_1150 != null)
            {
                return true;
            }

            focused = null;
            return false;
        }

        /// <summary>
        /// Retrieves the actively selected <see cref="UIBlock"/> for the provided <paramref name="controlID"/>, if it exists.
        /// </summary>
        /// <remarks>
        /// If the <see cref="SelectBehavior"/> of the focused element is set to <see cref="SelectBehavior.Click"/>,
        /// it will not be considered "selected" after it's clicked. Only elements whose <see cref="SelectBehavior"/> is set
        /// to <see cref="SelectBehavior.ScopeNavigation"/> or <see cref="SelectBehavior.FireEvents"/> are "selectable".
        /// </remarks>
        /// <param name="controlID">The unique identifier of the input control.</param>
        /// <param name="selected">The actively selected <see cref="UIBlock"/> for the given <paramref name="controlID"/>.</param>
        /// <returns>If a selected <see cref="UIBlock"/> is found and actively navigable, returns <c>true</c>. If the <see cref="UIBlock"/> was not found or is no longer navigable, returns <c>false</c>.</returns>
        public static bool TryGetSelectedUIBlock(uint controlID, out UIBlock selected)
        {
            selected = null;
            if (controlID < 0 || controlID >= InternalType_89.InternalField_2940)
            {
                return false;
            }

            selected = InternalType_757<UIBlock>.InternalMethod_3570(controlID);

            if (selected != null && selected.InternalProperty_23.InternalProperty_1150 != null)
            {
                return true;
            }

            selected = null;
            return false;
        }

        /// <summary>
        /// Performs a navigation-specific raycast against all navigable <see cref="UIBlock"/>s under <paramref name="scope"/> and retrieves a <see cref="UIBlockHit"/> for the nearest navigable <see cref="UIBlock"/> in the general direction of the provided <paramref name="ray"/>.
        /// </summary>
        /// <param name="ray">A ray, in worldspace, to use for the navigation-specific raycast.</param>
        /// <param name="blockHit">A <see cref="UIBlockHit"/> for the top-most-rendered navigable <see cref="UIBlock"/> in the provided <paramref name="ray"/>'s general direction.</param>
        /// <param name="ignore">The <see cref="UIBlock"/> to exclude from the results, defaults to <c>null</c>. Useful for when a specific <see cref="UIBlock"/> should be filtered out.</param>
        /// <param name="scope">The root of <see cref="UIBlock"/>s to test against, defaults to <c>null</c>. All <see cref="UIBlock"/>s in the scene are tested when <c><paramref name="scope"/> == null</c>.</param>
        /// <param name="navigablesOnly">Only include results with navigable elements? Defaults to <c>true</c>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <returns><c>true</c> if <i>any</i> <see cref="UIBlock"/> (on the <paramref name="layerMask"/>) is in the general direction of the provided <paramref name="ray"/>.</returns>
        public static bool NavCast(Ray ray, out UIBlockHit blockHit, UIBlock ignore = null, UIBlock scope = null, bool navigablesOnly = true, int layerMask = AllLayers)
        {
            InternalType_131 InternalVar_1 = scope == null ? InternalType_131.InternalField_415 : scope.InternalProperty_29;
            InternalType_131 InternalVar_2 = ignore == null ? InternalType_131.InternalField_415 : ignore.InternalProperty_29;

            if (InternalType_757<UIBlock>.InternalMethod_3581(ray, layerMask, InternalVar_1, InternalVar_2, navigablesOnly, out InternalType_428 InternalVar_3))
            {
                blockHit = InternalMethod_2889(InternalVar_3);
                return true;
            }

            blockHit = default;
            return false;
        }

        /// <summary>
        /// Performs a navigation-specific raycast against all navigable <see cref="UIBlock"/>s under <paramref name="scope"/> and populates the provided list of <see cref="UIBlockHit"/>s for all navigable <see cref="UIBlock"/>s in the general direction of the provided <paramref name="ray"/>.
        /// </summary>
        /// <param name="ray">A ray, in worldspace, to use for the navigation-specific raycast.</param>
        /// <param name="hitsToPopulate">The list to populate with all <see cref="UIBlockHit"/> collisions, sorted by closest to the ray origin and top-most-rendered (at index 0).</param>
        /// <param name="ignore">The <see cref="UIBlock"/> to exclude from the results, defaults to <c>null</c>. Useful for when a specific <see cref="UIBlock"/> should be filtered out.</param>
        /// <param name="scope">The root of <see cref="UIBlock"/>s to test against, defaults to <c>null</c>. All <see cref="UIBlock"/>s in the scene are tested when <c><paramref name="scope"/> == null</c>.</param>
        /// <param name="navigablesOnly">Only include results with navigable elements? Defaults to <c>true</c>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        public static void NavCastAll(Ray ray, List<UIBlockHit> hitsToPopulate, UIBlock ignore = null, UIBlock scope = null, bool navigablesOnly = true, int layerMask = AllLayers)
        {
            hitsToPopulate.Clear();

            InternalType_131 InternalVar_1 = scope == null ? InternalType_131.InternalField_415 : scope.InternalProperty_29;
            InternalType_131 InternalVar_2 = ignore == null ? InternalType_131.InternalField_415 : ignore.InternalProperty_29;

            InternalType_521<InternalType_428> InternalVar_3 = InternalType_757<UIBlock>.InternalMethod_3582(ray, layerMask, InternalVar_1, InternalVar_2, navigablesOnly);

            for (int InternalVar_4 = 0; InternalVar_4 < InternalVar_3.InternalProperty_433; ++InternalVar_4)
            {
                hitsToPopulate.Add(InternalMethod_2889(InternalVar_3[InternalVar_4]));
            }
        }

        #region 
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<InternalType_738> InternalProperty_1082 => InternalField_303[1];
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<InternalType_738> InternalProperty_1083 => InternalField_303[0];

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_95 InternalProperty_1084 => InternalField_3233[0];
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_95 InternalProperty_1085 => InternalField_3233[1];

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<InternalType_738>[] InternalField_303 = null;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InternalType_95[] InternalField_3233 = null;

        internal static void InternalMethod_3015()
        {
            if (!NovaApplication.IsPlaying)
            {
                return;
            }

            InternalField_303 = new List<InternalType_738>[] { new List<InternalType_738>(), new List<InternalType_738>() };
            InternalField_3233 = new InternalType_95[] { new InternalType_95(), new InternalType_95() };

            InternalType_757<UIBlock>.InternalEvent_12 -= InternalMethod_2687;
            InternalType_757<UIBlock>.InternalEvent_12 += InternalMethod_2687;

            InternalType_429.InternalEvent_13 -= InternalMethod_2688;
            InternalType_429.InternalEvent_13 += InternalMethod_2688;

            OnNavigationFocusChanged = null;
        }

        private static void InternalMethod_2688()
        {
            if (!NovaApplication.IsPlaying || !InternalType_64.InternalProperty_200.InternalProperty_742)
            {
                return;
            }

            InternalMethod_2690();

            List<InternalType_738> InternalVar_1 = InternalProperty_1083;
            InternalType_95 InternalVar_2 = InternalProperty_1084;

            if (InternalVar_1.Count == 0 && InternalVar_2.InternalProperty_1086 == 0)
            {
                return;
            }

            for (int InternalVar_3 = 0; InternalVar_3 < InternalVar_1.Count; ++InternalVar_3)
            {
                InternalType_738 InternalVar_4 = InternalVar_1[InternalVar_3];

                if (InternalVar_4.InternalField_3182 == InternalType_739.InternalField_3438)
                {
                    InternalVar_4 = InternalMethod_2891(InternalVar_4);
                }

                if (InternalVar_4.InternalField_3182 == InternalType_739.InternalField_3437)
                {
                    InternalVar_4 = InternalMethod_2823(InternalVar_4);
                }

                if (InternalVar_4.InternalField_3182 == InternalType_739.InternalField_2216)
                {
                    continue;
                }

                InternalMethod_2689(InternalVar_2, InternalVar_4);
            }

            InternalVar_1.Clear();

            InternalType_95 InternalVar_5 = InternalProperty_1085;

            InternalType_521<uint> InternalVar_6 = InternalVar_5.InternalProperty_1087;

            for (int InternalVar_7 = InternalVar_6.InternalProperty_433 - 1; InternalVar_7 >= 0; --InternalVar_7)
            {
                uint InternalVar_8 = InternalVar_6[InternalVar_7];

                if (InternalVar_5.InternalMethod_2822(InternalVar_8, out UIBlock InternalVar_9))
                {
                    InternalVar_2.InternalMethod_2797(InternalVar_8, InternalVar_9);
                    InternalVar_5.InternalMethod_2890(InternalVar_8);
                }
            }

            InternalVar_6 = InternalVar_2.InternalProperty_1087;

            for (int InternalVar_7 = 0; InternalVar_7 < InternalVar_6.InternalProperty_433; ++InternalVar_7)
            {
                uint InternalVar_8 = InternalVar_6[InternalVar_7];

                if (InternalVar_2.InternalMethod_2822(InternalVar_8, out UIBlock InternalVar_9))
                {
                    if (InternalVar_9 != null)
                    {
                        InternalType_757<UIBlock>.InternalMethod_3637(InternalVar_9, InternalVar_8, 0);
                    }

                    InternalMethod_2799(InternalVar_8, InternalVar_9);
                }
            }

            InternalVar_2.InternalMethod_2817();
        }

        private static void InternalMethod_2690()
        {
            List<InternalType_738> InternalVar_1 = InternalField_303[0];
            InternalField_303[0] = InternalField_303[1];
            InternalField_303[1] = InternalVar_1;

            InternalType_95 InternalVar_2 = InternalField_3233[0];
            InternalField_3233[0] = InternalField_3233[1];
            InternalField_3233[1] = InternalVar_2;
        }

        private static void InternalMethod_2687(uint InternalParameter_3022, UIBlock InternalParameter_3021, UIBlock InternalParameter_3020, int InternalParameter_2911)
        {
            if (InternalParameter_3020 == null)
            {
                InternalMethod_2818(InternalProperty_1085, InternalParameter_3021, InternalParameter_3020, InternalParameter_3022);
                return;
            }

            UIBlock InternalVar_1 = InternalType_757<UIBlock>.InternalMethod_3570(InternalParameter_3022);

            if (InternalVar_1 == InternalParameter_3020 && InternalType_757<UIBlock>.InternalMethod_3584(InternalVar_1, out Vector3 InternalVar_2, out Ray InternalVar_3, InternalParameter_2911, out UIBlock InternalVar_4))
            {
                InternalMethod_2689(InternalProperty_1085, InternalType_738.InternalMethod_2801(InternalParameter_3021, InternalVar_4, new Update(InternalVar_3, InternalParameter_3022), InternalVar_2, InternalParameter_2911));
            }
            else
            {
                InternalMethod_2689(InternalProperty_1085, InternalType_738.InternalMethod_2888(InternalParameter_3021, InternalParameter_3020, new Update(InternalMethod_2947(InternalParameter_3021, InternalParameter_3020), InternalParameter_3022), InternalParameter_2911));
            }
        }

        private static void InternalMethod_2689(InternalType_95 InternalParameter_2910, InternalType_738 InternalParameter_2459)
        {
            UIBlock InternalVar_1 = InternalParameter_2459.InternalField_2411;
            UIBlock InternalVar_2 = InternalParameter_2459.InternalField_2412;
            Update InternalVar_3 = InternalParameter_2459.InternalField_2414;
            Vector3 InternalVar_4 = InternalParameter_2459.InternalField_2410;
            int InternalVar_5 = InternalParameter_2459.InternalField_2395;

            if (InternalVar_2 == null && InternalVar_1 == null)
            {
                return;
            }

            InternalVar_1 = InternalVar_1 != null && InternalVar_1.InternalProperty_23.InternalProperty_1150 != null ? InternalVar_1 : null;

            bool InternalVar_6 = InternalParameter_2459.InternalField_3182 == InternalType_739.InternalField_2217;

            if (!InternalVar_6 && InternalVar_2 != null && InternalVar_1 == null)
            {
                InternalType_754 InternalVar_7 = InternalVar_2.InternalProperty_23.InternalProperty_1150;

                if (InternalVar_7 == null || !InternalVar_7.InternalMethod_3559(InternalVar_4))
                {
                    return;
                }

                GestureRecognizer InternalVar_8 = InternalVar_7 as GestureRecognizer;
                NavLink InternalVar_9 = InternalVar_8.Navigation.GetLink(InternalVar_4);

                switch (InternalVar_9.Fallback)
                {
                    case NavLinkFallback.DoNothing:
                        return;
                    case NavLinkFallback.FireDirectionEvent:
                        InternalVar_2.InternalMethod_91(Navigate.InternalMethod_461(InternalVar_3, InternalVar_2, InternalVar_4));
                        return;
                    case NavLinkFallback.NavigateOutsideScope:
                        int InternalVar_10 = 0;
                        UIBlock InternalVar_11 = InternalType_757<UIBlock>.InternalMethod_3571(InternalVar_3.ControlID, InternalVar_10++);

                        while (InternalVar_1 == null)
                        {
                            if (InternalType_757<UIBlock>.InternalMethod_3577(InternalVar_11, InternalVar_4, out InternalType_5 InternalVar_12))
                            {
                                InternalVar_1 = InternalVar_12 as UIBlock;
                                break;
                            }
                            
                            if (InternalVar_11 == null)
                            {
                                break;
                            }

                            UIBlock InternalVar_13 = InternalType_757<UIBlock>.InternalMethod_3571(InternalVar_3.ControlID, InternalVar_10++);

                            if (InternalType_757<UIBlock>.InternalMethod_3579(InternalVar_3.Ray, InternalVar_2, InternalVar_13, InternalVar_5, InternalParameter_3280: true, out InternalType_428 InternalVar_14))
                            {
                                InternalVar_1 = InternalVar_14.InternalField_1642 as UIBlock;
                                break;
                            }
                            
                            InternalVar_11 = InternalVar_13;
                        }
                        break;
                }
            }

            if (InternalVar_1 == null && !InternalVar_6)
            {
                return;
            }

            InternalMethod_2818(InternalParameter_2910, InternalVar_2, InternalVar_1, InternalVar_3.ControlID);

            InternalType_521<UIBlock> InternalVar_15 = InternalType_757<UIBlock>.InternalMethod_3636(InternalVar_1, InternalType_757<UIBlock>.InternalMethod_3570(InternalVar_3.ControlID), InternalVar_5);

            UIBlock InternalVar_16 = InternalVar_15.InternalProperty_433 > 0 ? InternalVar_15[0] : InternalVar_1;

            while (!InternalType_757<UIBlock>.InternalMethod_3575(InternalVar_3.ControlID, InternalVar_16))
            {
                UIBlock InternalVar_17 = InternalType_757<UIBlock>.InternalMethod_3574(InternalVar_3.ControlID);
                InternalVar_17.InternalMethod_91(Navigate.InternalMethod_2058(InternalVar_3, InternalVar_17));
            }

            for (int InternalVar_17 = 0; InternalVar_17 < InternalVar_15.InternalProperty_433; ++InternalVar_17)
            {
                InternalType_757<UIBlock>.InternalMethod_3569(InternalVar_3.ControlID, InternalVar_15[InternalVar_17], InternalVar_5);
                Select(InternalVar_3.ControlID, InternalVar_3.UserData, InternalVar_5);
            }

            InternalType_757<UIBlock>.InternalMethod_3569(InternalVar_3.ControlID, InternalVar_1, InternalVar_5);

            Ray InternalVar_18 = InternalVar_3.Ray;

            if (InternalVar_2 != null)
            {
                Vector3 InternalVar_19 = InternalVar_2.transform.InverseTransformDirection(InternalVar_18.direction);
                InternalVar_2.InternalMethod_91(Navigate.InternalMethod_1883(InternalVar_3, InternalVar_2, InternalVar_1, InternalVar_19));
            }

            if (InternalVar_1 != null)
            {
                Vector3 InternalVar_19 = InternalVar_1.transform.InverseTransformDirection(InternalVar_18.direction);
                InternalVar_1.InternalMethod_91(Navigate.InternalMethod_507(InternalVar_3, InternalVar_1, InternalVar_2, InternalVar_19));

                if (InternalParameter_2459.InternalField_3340 && InternalVar_1.InternalProperty_23.InternalProperty_1150 is GestureRecognizer recognizer && recognizer.AutoSelect)
                {
                    Select(InternalVar_3.ControlID, InternalVar_3.UserData, InternalVar_5);

                    if (InternalVar_2 != null)
                    {
                        InternalVar_3.Ray = InternalType_757<UIBlock>.InternalMethod_3583(InternalVar_4, InternalVar_2);
                    }

                    if (recognizer.OnSelect == SelectBehavior.ScopeNavigation && InternalType_757<UIBlock>.InternalMethod_3579(InternalVar_3.Ray, InternalVar_1, InternalVar_1, InternalVar_5, InternalParameter_3280: true, out InternalType_428 InternalVar_20, InternalParameter_3283: true))
                    {
                        InternalMethod_2689(InternalParameter_2910, InternalType_738.InternalMethod_2801(InternalVar_1, InternalVar_20.InternalField_1642 as UIBlock, InternalVar_3, InternalVar_19, InternalVar_5));
                    }
                }
            }
        }

        private static InternalType_738 InternalMethod_2891(InternalType_738 InternalParameter_2458)
        {
            UIBlock InternalVar_1 = InternalParameter_2458.InternalField_2412;

            if (InternalVar_1.ChildCount == 0)
            {
                return InternalType_738.InternalField_2218;
            }

            uint InternalVar_2 = InternalParameter_2458.InternalField_2409;

            if (InternalType_757<UIBlock>.InternalMethod_3568(InternalVar_2) != InternalVar_1)
            {
                return InternalType_738.InternalField_2218;
            }

            object InternalVar_3 = InternalParameter_2458.InternalField_2413;
            int InternalVar_4 = InternalParameter_2458.InternalField_2395;

            bool InternalVar_5 = true;

            if (InternalType_757<UIBlock>.InternalMethod_3584(InternalVar_1, out Vector3 InternalVar_6, out Ray InternalVar_7, InternalVar_4, out UIBlock InternalVar_8))
            {
                InternalVar_5 = false;

                if (((1 << InternalVar_8.gameObject.layer) & InternalVar_4) != 0)
                {
                    return InternalType_738.InternalMethod_2801(InternalVar_1, InternalVar_8, new Update(InternalVar_7, InternalVar_2, InternalVar_3), InternalVar_6, InternalVar_4);
                }
            }

            if (InternalVar_5)
            {
                AutoLayout InternalVar_9 = InternalVar_1.InternalMethod_79();

                if (!InternalVar_9.Enabled)
                {
                    return InternalType_738.InternalField_2218;
                }

                InternalVar_6 = Vector3.zero;
                InternalVar_6[InternalVar_9.Axis.Index()] = InternalVar_9.InternalProperty_13;

                InternalVar_7 = InternalType_757<UIBlock>.InternalMethod_3583(InternalVar_6, InternalVar_1, InternalParameter_3305: true);
            }

            if (InternalType_757<UIBlock>.InternalMethod_3579(InternalVar_7, InternalVar_1, InternalVar_1, InternalVar_4, InternalParameter_3280: true, out InternalType_428 InternalVar_10))
            {
                return InternalType_738.InternalMethod_2801(InternalVar_1, InternalVar_10.InternalField_1642 as UIBlock, new Update(InternalVar_7, InternalVar_2, InternalVar_3), InternalVar_6, InternalVar_4);
            }

            return InternalType_738.InternalField_2218;
        }


        private static InternalType_738 InternalMethod_2823(InternalType_738 InternalParameter_2457)
        {
            uint InternalVar_1 = InternalParameter_2457.InternalField_2409;
            Vector3 InternalVar_2 = InternalParameter_2457.InternalField_2410;
            object InternalVar_3 = InternalParameter_2457.InternalField_2413;
            int InternalVar_4 = InternalParameter_2457.InternalField_2395;

            UIBlock InternalVar_5 = InternalType_757<UIBlock>.InternalMethod_3568(InternalVar_1);

            if (InternalVar_5 == null)
            {
                return InternalType_738.InternalField_2218;
            }

            UIBlock InternalVar_6 = InternalType_757<UIBlock>.InternalMethod_3570(InternalVar_1);

            UIBlock InternalVar_7 = null;

            bool InternalVar_8 = InternalVar_5 == InternalVar_6;
            Ray InternalVar_9 = InternalType_757<UIBlock>.InternalMethod_3583(InternalVar_2, InternalVar_5, InternalParameter_3305: InternalVar_8);

            if (InternalType_757<UIBlock>.InternalMethod_3579(InternalVar_9, InternalVar_5, InternalVar_6, InternalVar_4, InternalParameter_3280: true, out InternalType_428 InternalVar_10))
            {
                InternalVar_7 = InternalVar_10.InternalField_1642 as UIBlock;
            }
            else if (InternalVar_8)
            {
                InternalVar_9 = InternalType_757<UIBlock>.InternalMethod_3583(InternalVar_2, InternalVar_5, InternalParameter_3305: false);
            }

            return InternalParameter_2457.InternalMethod_2986(InternalVar_5, InternalVar_7, new Update(InternalVar_9, InternalVar_1, InternalVar_3));
        }

        private static void InternalMethod_2818(InternalType_95 InternalParameter_2456, UIBlock InternalParameter_2450, UIBlock InternalParameter_2449, uint InternalParameter_2448)
        {
            if (InternalParameter_2450 == InternalParameter_2449)
            {
                return;
            }

            InternalParameter_2456.InternalMethod_2797(InternalParameter_2448, InternalParameter_2449);
        }

        private static void InternalMethod_2799(uint InternalParameter_2447, UIBlock InternalParameter_2446)
        {
            try
            {
                OnNavigationFocusChanged?.Invoke(InternalParameter_2447, InternalParameter_2446);
            }
            catch (System.Exception e)
            {
                Debug.LogException(e);
            }
        }

        private static Ray InternalMethod_2947(UIBlock InternalParameter_2484, UIBlock InternalParameter_120)
        {
            bool InternalVar_1 = InternalParameter_2484 != null;
            bool InternalVar_2 = InternalParameter_120 != null;

            if (!InternalVar_1 && !InternalVar_2)
            {
                return default;
            }

            if (!InternalVar_1)
            {
                return new Ray(InternalParameter_120.transform.position, InternalParameter_120.transform.forward);
            }

            if (!InternalVar_2)
            {
                return new Ray(InternalParameter_2484.transform.position, InternalParameter_2484.transform.forward);
            }

            return new Ray(InternalParameter_2484.transform.position, (InternalParameter_120.transform.position - InternalParameter_2484.transform.position).normalized);
        }

        private static UIBlockHit InternalMethod_2889(InternalType_428 InternalParameter_121)
        {
            return new UIBlockHit()
            {
                UIBlock = InternalParameter_121.InternalField_1642 as UIBlock,
                Position = InternalParameter_121.InternalField_1643,
                Normal = InternalParameter_121.InternalField_1644
            };
        }

        private enum InternalType_739
        {
            InternalField_2216,
            InternalField_2217,
            InternalField_2924,
            InternalField_3437,
            InternalField_3438,
        }

        private readonly struct InternalType_738
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly InternalType_739 InternalField_3182;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly bool InternalField_3340;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly UIBlock InternalField_2412;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly UIBlock InternalField_2411;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Update InternalField_2414;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly uint InternalField_2409;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Vector3 InternalField_2410;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly object InternalField_2413;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly int InternalField_2395;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly InternalType_738 InternalField_2218 = new InternalType_738(InternalType_739.InternalField_2216);

            public static InternalType_738 InternalMethod_2888(UIBlock InternalParameter_2668, UIBlock InternalParameter_2667, Update InternalParameter_3132, int InternalParameter_3133, bool InternalParameter_3134 = false) => new InternalType_738(InternalParameter_2668, InternalParameter_2667, InternalParameter_3132, InternalParameter_3133, InternalParameter_3134);
            public static InternalType_738 InternalMethod_2801(UIBlock InternalParameter_3135, UIBlock InternalParameter_3136, Update InternalParameter_3137, Vector3 InternalParameter_3138, int InternalParameter_3139) => new InternalType_738(InternalParameter_3135, InternalParameter_3136, InternalParameter_3137, InternalParameter_3138, InternalParameter_3139);
            public static InternalType_738 InternalMethod_2815(uint InternalParameter_3140, Vector3 InternalParameter_3141, object InternalParameter_3142, int InternalParameter_3143) => new InternalType_738(InternalParameter_3140, InternalParameter_3141, InternalParameter_3142, InternalParameter_3143);
            public static InternalType_738 InternalMethod_2796(uint InternalParameter_3144, UIBlock InternalParameter_3145, object InternalParameter_3146, int InternalParameter_3147) => new InternalType_738(InternalParameter_3145, InternalParameter_3144, InternalParameter_3146, InternalParameter_3147);

            public InternalType_738 InternalMethod_2986(UIBlock InternalParameter_3148, UIBlock InternalParameter_3149, Update InternalParameter_3150)
            {
                return new InternalType_738(InternalParameter_3148, InternalParameter_3149, InternalParameter_3150, InternalField_2410, InternalField_2395);
            }

            private InternalType_738(InternalType_739 InternalParameter_3151)
            {
                InternalField_3182 = InternalParameter_3151;
                InternalField_2412 = null;
                InternalField_2411 = null;
                InternalField_2414 = Update.Uninitialized;
                InternalField_3340 = false;

                InternalField_2409 = uint.MaxValue;
                InternalField_2410 = Vector3.zero;
                InternalField_2413 = null;
                InternalField_2395 = 0;
            }

            private InternalType_738(UIBlock InternalParameter_3152, UIBlock InternalParameter_3153, Update InternalParameter_3154, int InternalParameter_3155, bool InternalParameter_3156)
            {
                InternalField_3182 = InternalType_739.InternalField_2217;
                InternalField_2412 = InternalParameter_3152;
                InternalField_2411 = InternalParameter_3153;
                InternalField_2414 = InternalParameter_3154;
                InternalField_2395 = InternalParameter_3155;
                InternalField_3340 = InternalParameter_3156;

                InternalField_2409 = uint.MaxValue;
                InternalField_2410 = Vector3.zero;
                InternalField_2413 = null;
            }

            private InternalType_738(UIBlock InternalParameter_3157, UIBlock InternalParameter_3158, Update InternalParameter_3159, Vector3 InternalParameter_3160, int InternalParameter_3161)
            {
                InternalField_3182 = InternalType_739.InternalField_2924;
                InternalField_2412 = InternalParameter_3157;
                InternalField_2411 = InternalParameter_3158;
                InternalField_2414 = InternalParameter_3159;
                InternalField_3340 = true;

                InternalField_2409 = InternalParameter_3159.ControlID;
                InternalField_2410 = InternalParameter_3160;
                InternalField_2413 = InternalParameter_3159.UserData;
                InternalField_2395 = InternalParameter_3161;
            }

            private InternalType_738(UIBlock InternalParameter_3162, uint InternalParameter_3163, object InternalParameter_3164, int InternalParameter_3165)
            {
                InternalField_3182 = InternalType_739.InternalField_3438;

                InternalField_2409 = InternalParameter_3163;
                InternalField_2413 = InternalParameter_3164;
                InternalField_2395 = InternalParameter_3165;
                InternalField_2412 = InternalParameter_3162;
                InternalField_3340 = true;

                InternalField_2411 = null;
                InternalField_2414 = Update.Uninitialized;
                InternalField_2410 = Vector3.zero;
            }

            private InternalType_738(uint InternalParameter_3166, Vector3 InternalParameter_3167, object InternalParameter_3168, int InternalParameter_3169)
            {
                InternalField_3182 = InternalType_739.InternalField_3437;

                InternalField_2409 = InternalParameter_3166;
                InternalField_2410 = InternalParameter_3167;
                InternalField_2413 = InternalParameter_3168;
                InternalField_2395 = InternalParameter_3169;
                InternalField_3340 = true;

                InternalField_2412 = null;
                InternalField_2411 = null;
                InternalField_2414 = Update.Uninitialized;
            }
        }

        private class InternalType_95
        {
            private struct InternalType_727 : System.IEquatable<InternalType_727>
            {
                [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public readonly bool InternalField_3163;
                [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
                public readonly UIBlock InternalField_3177;

                public static implicit operator InternalType_727(UIBlock InternalParameter_2648) => new InternalType_727(InternalParameter_2648);

                private InternalType_727(UIBlock InternalParameter_2669)
                {
                    InternalField_3177 = InternalParameter_2669;
                    InternalField_3163 = InternalParameter_2669 == null;
                }

                public bool Equals(InternalType_727 other)
                {
                    return this.InternalField_3177 == other.InternalField_3177 && this.InternalField_3163 == other.InternalField_3163;
                }
            }

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public int InternalProperty_1086 => InternalField_3168.Count;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public InternalType_521<uint> InternalProperty_1087 => InternalField_3168.InternalMethod_2043();
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private List<uint> InternalField_3168 = new List<uint>();
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private Dictionary<uint, InternalType_727> InternalField_3093 = new Dictionary<uint, InternalType_727>();

            public void InternalMethod_2797(uint InternalParameter_122, UIBlock InternalParameter_2652)
            {
                bool InternalVar_2 = InternalField_3093.TryGetValue(InternalParameter_122, out InternalType_727 InternalVar_1);
                bool InternalVar_3 = !InternalVar_2 || !InternalVar_1.Equals(InternalParameter_2652);

                if (!InternalVar_3)
                {
                    return;
                }

                if (!InternalVar_2)
                {
                    InternalField_3168.Add(InternalParameter_122);
                }

                InternalField_3093[InternalParameter_122] = InternalParameter_2652;
            }

            public void InternalMethod_2890(uint InternalParameter_2651)
            {
                if (!InternalField_3093.Remove(InternalParameter_2651))
                {
                    return;
                }

                InternalField_3168.Remove(InternalParameter_2651);
            }

            public bool InternalMethod_2822(uint InternalParameter_2650, out UIBlock InternalParameter_2649)
            {
                bool InternalVar_2 = InternalField_3093.TryGetValue(InternalParameter_2650, out InternalType_727 InternalVar_1);
                InternalParameter_2649 = InternalVar_2 ? InternalVar_1.InternalField_3177 : null;
                return InternalVar_2;
            }

            public void InternalMethod_2817()
            {
                InternalField_3168.Clear();
                InternalField_3093.Clear();
            }
        }

        #endregion
    }
}
