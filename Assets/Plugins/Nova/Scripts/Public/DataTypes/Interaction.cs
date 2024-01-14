// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0;
using Nova.InternalNamespace_0.InternalNamespace_4;
using Nova.InternalNamespace_0.InternalNamespace_11;
using Nova.InternalNamespace_0.InternalNamespace_5;
using Nova.InternalNamespace_0.InternalNamespace_5.InternalNamespace_6;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;

using InputRouter = Nova.InternalNamespace_0.InternalType_90<Nova.UIBlockHit>.InternalType_91;
using Navigator = Nova.InternalNamespace_0.InternalType_757<Nova.UIBlock>;

namespace Nova
{
    /// <summary>
    /// A way to indicate the physical stability of an input device as it's used to perform various interactions.
    /// </summary>
    /// <remarks>
    /// Some examples:
    /// <list type="table">
    /// <item>
    /// <term>High Accuracy</term>
    /// <description>
    /// <list type="bullet">
    /// <item><description>Mouse</description></item>
    /// <item><description>Finger (touchscreen)</description></item>
    /// <item><description>Stylus (touchscreen)</description></item>
    /// <item><description>XR Controller Ray</description></item>
    /// </list>
    /// </description>
    /// </item>
    /// <item><term>Low Accuracy</term>
    /// <description>
    /// <list type="bullet">
    /// <item><description>XR Hands</description></item>
    /// <item><description>XR Finger Tips</description></item>
    /// </list>
    /// </description>
    /// </item>
    /// </list>
    /// </remarks>
    public enum InputAccuracy
    {
        /// <summary>
        /// High accuracy, physically stable.
        /// </summary>
        High = 0,
        /// <summary>
        /// Lower accuracy, less physically stable.
        /// </summary>
        Low = 1
    }

    internal static class InternalType_491
    {
        public static InternalType_432 InternalMethod_2349(ref this Sphere InternalParameter_2156)
        {
            return new InternalType_432() { InternalField_1663 = InternalParameter_2156.Center, InternalField_1664 = InternalParameter_2156.Radius };
        }
    }

    internal static class InternalType_490
    {
        public static InternalNamespace_0.InternalType_78 InternalMethod_2204(this Interaction.Update InternalParameter_2155)
        {
            return new InternalNamespace_0.InternalType_78(InternalParameter_2155.Ray, InternalParameter_2155.ControlID, InternalParameter_2155.UserData);
        }

        public static Interaction.Update InternalMethod_2179(ref this InternalNamespace_0.InternalType_78 InternalParameter_2154)
        {
            return new Interaction.Update(InternalParameter_2154.InternalField_258, InternalParameter_2154.InternalField_257, InternalParameter_2154.InternalField_259);
        }
    }


    /// <summary>
    /// The details of a <see cref="Ray"/>-><see cref="Nova.UIBlock"/> or <see cref="Sphere"/>-><see cref="Nova.UIBlock"/> intersection.
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item><description><see cref="Interaction.Raycast(Ray, out UIBlockHit, float, int)"/></description></item>
    /// <item><description><see cref="Interaction.RaycastAll(Ray, List{UIBlockHit}, float, int)"/></description></item>
    /// <item><description><see cref="Interaction.SphereCollide(Sphere, out UIBlockHit, int)"/></description></item>
    /// <item><description><see cref="Interaction.SphereCollideAll(Sphere, List{UIBlockHit}, int)"/></description></item>
    /// </list>
    /// </remarks>
    [System.Serializable]
    public struct UIBlockHit : System.IEquatable<UIBlockHit>, InternalType_84
    {
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        InternalType_5 InternalType_84.InternalProperty_169 { get => UIBlock; set => UIBlock = value as UIBlock; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_84.InternalProperty_170 { get => Position; set => Position = value; }
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        Vector3 InternalType_84.InternalProperty_171 { get => Normal; set => Normal = value; }

        /// <summary>
        /// The UI Block that was hit.
        /// </summary>
        public UIBlock UIBlock;

        /// <summary>
        /// The hit position on the UI Block in world space.
        /// </summary>
        public Vector3 Position;

        /// <summary>
        /// The hit normal in world space.
        /// </summary>
        public Vector3 Normal;

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if <c><paramref name="lhs"/>.UIBlock == <paramref name="rhs"/>.UIBlock &amp;&amp; <paramref name="lhs"/>.Position == <paramref name="rhs"/>.Position &amp;&amp; <paramref name="lhs"/>.Normal == <paramref name="rhs"/>.Normal.</c>
        /// </returns>
        public static bool operator ==(UIBlockHit lhs, UIBlockHit rhs)
        {
            return lhs.UIBlock == rhs.UIBlock && lhs.Position == rhs.Position && lhs.Normal == rhs.Normal;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if <c><paramref name="lhs"/>.UIBlock != <paramref name="rhs"/>.UIBlock || <paramref name="lhs"/>.Position != <paramref name="rhs"/>.Position || <paramref name="lhs"/>.Normal != <paramref name="rhs"/>.Normal</c>.
        /// </returns>
        public static bool operator !=(UIBlockHit lhs, UIBlockHit rhs)
        {
            return lhs.UIBlock != rhs.UIBlock || lhs.Position != rhs.Position || lhs.Normal != rhs.Normal;
        }

        /// <summary>
        /// The hashcode for this <see cref="UIBlockHit"/>.
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Position.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Normal.GetHashCode();

            if (UIBlock != null)
            {
                InternalVar_1 = (InternalVar_1 * 7) + UIBlock.GetHashCode();
            }

            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="UIBlockHit"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if <c>this == <paramref name="other"/></c>.
        /// </returns>
        public override bool Equals(object other)
        {
            if (other is UIBlockHit hit)
            {
                return this == hit;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="UIBlockHit"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if <c>this == <paramref name="other"/></c>.
        /// </returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(UIBlockHit other)
        {
            return this == other;
        }
    }

    /// <summary>
    /// The static access point to provide input events and leverage the Nova input system.
    /// </summary>
    public static class Interaction
    {
        /// <summary>
        /// Represents a single update of an interaction.
        /// </summary>
        /// <seealso cref="Interaction.Point(Update, bool, bool, float, int, InputAccuracy)"/>
        /// <seealso cref="Interaction.Scroll(Update, Vector3, float, int, InputAccuracy)"/>
        /// <seealso cref="Interaction.Cancel(Update)"/>
        /// <seealso cref="IGestureEvent"/>
        public struct Update : System.IEquatable<Update>
        {
            /// <summary>
            /// The <see cref="ControlID"/> of <see cref="Uninitialized"/>.
            /// </summary>
            public const uint UninitializedControlID = uint.MaxValue;

            /// <summary>
            /// Represents an uninitialized interaction.
            /// </summary>
            public static readonly Update Uninitialized = new Update(UninitializedControlID);

            /// <summary>
            /// The unique identifier of the input control.
            /// </summary>
            /// <remarks>Likely represents a single finger on a touchscreen, a mouse button, a joystick, etc.</remarks>
            public uint ControlID;

            /// <summary>
            /// The pointer ray in world space.
            /// </summary>
            public Ray Ray;

            /// <summary>
            /// Any additional data to pass along to the receiver of the current interaction.
            /// </summary>
            public object UserData;

            /// <summary>
            /// Create a new <see cref="Update"/>.
            /// </summary>
            /// <param name="ray">The world space ray indicating where the input control is "pointing".</param>
            /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.</param>
            /// <param name="userData">Any additional data to pass along to the receiver of the current interaction.</param>
            public Update(Ray ray, uint controlID = 0, object userData = null)
            {
                Ray = ray;
                ControlID = controlID;
                UserData = userData;
            }

            /// <summary>
            /// Create an interaction without a <see cref="Ray"/> or <see cref="UserData"/>.
            /// </summary>
            /// <remarks>Useful for when the caller just wants a wrapped <see cref="ControlID"/>.</remarks>
            /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.
            /// </param>
            public Update(uint controlID)
            {
                ControlID = controlID;
                Ray = new Ray(InternalType_187.InternalField_535, InternalType_187.InternalField_535);
                UserData = null;
            }

            /// <summary>
            /// Equality operator.
            /// </summary>
            /// <param name="lhs">Left hand side.</param>
            /// <param name="rhs">Right hand side.</param>
            /// <returns><see langword="true"/> if all fields of <paramref name="lhs"/> are equal to all field of <paramref name="rhs"/>.</returns>
            public static bool operator ==(Update lhs, Update rhs)
            {
                return lhs.ControlID == rhs.ControlID &&
                       lhs.Ray.origin == rhs.Ray.origin &&
                       lhs.Ray.direction == rhs.Ray.direction &&
                       lhs.UserData == rhs.UserData;
            }

            /// <summary>
            /// Inequality operator
            /// </summary>
            /// <param name="lhs">Left hand side</param>
            /// <param name="rhs">Right hand side</param>
            /// <returns><see langword="true"/> if any field of <paramref name="lhs"/> is <b>not</b> equal to its corresponding field of <paramref name="rhs"/>.</returns>
            public static bool operator !=(Update lhs, Update rhs)
            {
                return !(lhs == rhs);
            }

            /// <summary>
            /// The hashcode for this <see cref="Update"/>.
            /// </summary>
            public override int GetHashCode()
            {
                int InternalVar_1 = 13;
                InternalVar_1 = (InternalVar_1 * 7) + ControlID.GetHashCode();
                InternalVar_1 = (InternalVar_1 * 7) + Ray.GetHashCode();

                if (UserData != null)
                {
                    InternalVar_1 = (InternalVar_1 * 7) + UserData.GetHashCode();
                }

                return InternalVar_1;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The other <see cref="Update"/> to compare.</param>
            /// <returns>
            /// <see langword="true"/> if <c>this == <paramref name="other"/></c>.
            /// </returns>
            public override bool Equals(object other)
            {
                if (other is Update ray)
                {
                    return this == ray;
                }

                return false;
            }

            /// <summary>
            /// Equality compare.
            /// </summary>
            /// <param name="other">The other <see cref="Update"/> to compare.</param>
            /// <returns>
            /// <see langword="true"/> if <c>this == <paramref name="other"/></c>.
            /// </returns>
            public bool Equals(Update other)
            {
                return this == other;
            }

            /// <summary>
            /// The string representation of this <see cref="Update"/>.
            /// </summary>
            public override string ToString()
            {
                return UserData != null ? $"ControlID = {ControlID}, Ray = {Ray}, UseData = {UserData}" : $"ControlID = {ControlID}, Ray = {Ray}";
            }
        }

        /// <summary>
        /// A layer mask to select all GameObject layers, equivalent to <c>Physics.AllLayers</c>.
        /// </summary>
        public const int AllLayers = InternalType_178.InternalField_469;
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private const float InternalField_3301 = 10;

        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static InputRouter InternalField_3274 = new InputRouter();
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<InternalType_428> InternalField_3273 = new List<InternalType_428>();
        [System.NonSerialized]
        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        private static List<UIBlockHit> InternalField_3272 = new List<UIBlockHit>();

        internal static void InternalMethod_3196()
        {
            if (!Compat.NovaApplication.IsPlaying)
            {
                return;
            }

            InternalField_3274.InternalMethod_505();
        }

        /// <summary>
        /// Retrieves the latest valid <see cref="UIBlockHit"/> to receive an interaction event from the provided <paramref name="controlID"/>.
        /// </summary>
        /// <param name="controlID">The unique identifier of the input control.</param>
        /// <param name="receiverHit">The latest valid <see cref="UIBlockHit"/> created with the same <paramref name="controlID"/>.</param>
        /// <returns>If a receiver is found and the interaction is valid, returns <see langword="true"/>. If the receiver was not found or the interaction has been canceled, returns <see langword="false"/>.</returns>
        public static bool TryGetActiveReceiver(uint controlID, out UIBlockHit receiverHit)
        {
            if (InternalField_3274.InternalMethod_503<bool>(controlID, out receiverHit))
            {
                return true;
            }

            return InternalField_3274.InternalMethod_503<InternalType_755<Vector3>>(controlID, out receiverHit);
        }

        /// <summary>
        /// Performs a sphere collision against all active <see cref="UIBlock"/>s in the scene and populates the provided list with <see cref="UIBlockHit"/>s for all <see cref="UIBlock"/>s colliding with the provided <paramref name="sphere"/>.
        /// </summary>
        /// <remarks>Performed by the Nova Input System, independent of the <see cref="Physics"/> and <see cref="Physics2D"/> systems.</remarks>
        /// <param name="sphere">The sphere, in world space, to cast</param>
        /// <param name="hitsToPopulate">The list to populate with all <see cref="UIBlockHit"/> collisions, sorted by top-most-rendered (at index 0).</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <exception cref="System.ArgumentNullException">if <c><paramref name="hitsToPopulate"/> == null</c>.</exception>
        public static void SphereCollideAll(Sphere sphere, List<UIBlockHit> hitsToPopulate, int layerMask = AllLayers)
        {
            if (hitsToPopulate == null)
            {
                throw new System.ArgumentNullException($"Provided list of {nameof(hitsToPopulate)} is null.");
            }

            InternalMethod_3195(sphere.InternalMethod_2349(), InternalField_3273, hitsToPopulate, layerMask);
        }

        /// <summary>
        /// Performs a sphere collision test against all active <see cref="UIBlock"/>s in the scene and retrieves a <see cref="UIBlockHit"/> for the top-most-rendered <see cref="UIBlock"/> colliding with the provided <paramref name="sphere"/>.
        /// </summary>
        /// <remarks>Performed by the Nova Input System, independent of the <see cref="Physics"/> and <see cref="Physics2D"/> systems.</remarks>
        /// <param name="sphere">The sphere, in world space, to cast</param>
        /// <param name="blockHit">A <see cref="UIBlockHit"/> for the top-most-rendered <see cref="UIBlock"/> colliding with the provided <paramref name="sphere"/>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <returns><see langword="true"/> if <i>any</i> <see cref="UIBlock"/> (on the <paramref name="layerMask"/>) collides with the provided <paramref name="sphere"/>.</returns>
        public static bool SphereCollide(Sphere sphere, out UIBlockHit blockHit, int layerMask = AllLayers)
        {
            if (InternalType_429.InternalProperty_200.InternalMethod_1690(sphere.InternalMethod_2349(), out InternalType_428 InternalVar_1, layerMask))
            {
                blockHit.UIBlock = InternalVar_1.InternalField_1642 as UIBlock;
                blockHit.Position = InternalVar_1.InternalField_1643;
                blockHit.Normal = InternalVar_1.InternalField_1644;
                return InternalVar_1.InternalField_1642 != null;
            }

            blockHit.UIBlock = null;
            blockHit.Position = InternalType_187.InternalField_550;
            blockHit.Normal = InternalType_187.InternalField_550;
            return false;
        }

        /// <summary>
        /// Performs a raycast against all active <see cref="UIBlock"/>s in the scene and populates the provided list with <see cref="UIBlockHit"/>s for all <see cref="UIBlock"/>s intersecting with the provided <paramref name="ray"/>.
        /// </summary>
        /// <remarks>Performed by the Nova Input System, independent of the <see cref="Physics"/> and <see cref="Physics2D"/> systems.</remarks>
        /// <param name="ray">The ray, in world space, to cast</param>
        /// <param name="hitsToPopulate">The list to populate with all <see cref="UIBlockHit"/> collisions, sorted by top-most-rendered (at index 0).</param>
        /// <param name="maxDistance">The max distance from the ray origin (in world space) to consider an intersection point a "hit".</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <exception cref="System.ArgumentNullException">if <c><paramref name="hitsToPopulate"/> == null</c>.</exception>
        public static void RaycastAll(Ray ray, List<UIBlockHit> hitsToPopulate, float maxDistance = float.PositiveInfinity, int layerMask = AllLayers)
        {
            InternalMethod_3009(ray, InternalField_3273, hitsToPopulate, maxDistance, layerMask);
        }

        /// <summary>
        /// Performs a raycast against all active <see cref="UIBlock"/>s in the scene and retrieves a <see cref="UIBlockHit"/> for the top-most-rendered <see cref="UIBlock"/> colliding with the provided <paramref name="ray"/>.
        /// </summary>
        /// <remarks>Performed by the Nova Input System, independent of the <see cref="Physics"/> and <see cref="Physics2D"/> systems.</remarks>
        /// <param name="ray">The ray, in world space, to cast</param>
        /// <param name="blockHit">A <see cref="UIBlockHit"/> for the top-most-rendered <see cref="UIBlock"/> colliding with the provided <paramref name="ray"/>.</param>
        /// <param name="maxDistance">The max distance from the ray origin (in world space) to consider an intersection point a "hit".</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <returns><see langword="true"/> if <i>any</i> <see cref="UIBlock"/> (on the <paramref name="layerMask"/> and within range) collides with the provided <paramref name="ray"/>.</returns>
        public static bool Raycast(Ray ray, out UIBlockHit blockHit, float maxDistance = float.PositiveInfinity, int layerMask = AllLayers)
        {
            if (InternalType_429.InternalProperty_200.InternalMethod_1691(ray, out InternalType_428 InternalVar_1, maxDistance, layerMask))
            {
                blockHit.UIBlock = InternalVar_1.InternalField_1642 as UIBlock;
                blockHit.Position = InternalVar_1.InternalField_1643;
                blockHit.Normal = InternalVar_1.InternalField_1644;
                return InternalVar_1.InternalField_1642 != null;
            }

            blockHit.UIBlock = null;
            blockHit.Position = InternalType_187.InternalField_550;
            blockHit.Normal = InternalType_187.InternalField_550;
            return false;
        }

        /// <summary>
        /// Performs a sphere collision test with the provided <see cref="Sphere"/>, 
        /// creates an <see cref="Update"/> from the results, and routes the <see cref="Update"/>
        /// to the collided <see cref="UIBlock"/> or the <see cref="UIBlock"/> currently capturing 
        /// the active interaction.
        /// </summary>
        /// <remarks>
        /// Point updates are only delivered to <see cref="UIBlock"/>s with an attached 
        /// <see cref="Interactable"/> or <see cref="Scroller"/> component.<br/><br/>
        /// To get the most reliable behavior between potentially conflicting press, drag,
        /// and scroll gestures, the entry point of the overlapping target <see cref="UIBlock"/>s
        /// <b>must</b> all be coplanar. If the entry points aren't coplanar, say a scrollable <see cref="ListView"/>'s 
        /// front face is positioned behind a draggable list item's front face, attempts to scroll the <see cref="ListView"/>
        /// will likely fail, and the list item will be dragged instead.
        /// </remarks>
        /// <param name="sphere">The sphere, in world space, to cast</param>
        /// <param name="controlID">The unique identifier of the input control generating this <see cref="Update"/>.</param>
        /// <param name="userData">Any additional data to pass along to the receiver of the current interaction. See <see cref="Update.UserData"/>.</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <param name="accuracy">The accuracy of the input source, defaults to <see cref="InputAccuracy.Low"/>.</param>
        /// <seealso cref="Point(Update, bool, bool, float, int, InputAccuracy)"/>
        /// <seealso cref="Raycast(Ray, out UIBlockHit, float, int)"/>
        /// <seealso cref="RaycastAll(Ray, List{UIBlockHit}, float, int)"/>
        /// <seealso cref="SphereCollide(Sphere, out UIBlockHit, int)"/>
        /// <seealso cref="SphereCollideAll(Sphere, List{UIBlockHit}, int)"/>
        /// <seealso cref="Cancel(Update)"/>
        public static void Point(Sphere sphere, uint controlID, object userData = null, int layerMask = AllLayers, InputAccuracy accuracy = InputAccuracy.Low)
        {
            if (controlID < 0 || controlID >= InputRouter.InternalField_2940)
            {
                throw new System.ArgumentException($"Invalid Control ID [{controlID}]. Expected within range [0, {InputRouter.InternalField_2940}]");
            }

            InternalType_432 InternalVar_1 = sphere.InternalMethod_2349();
            InternalMethod_3195(InternalVar_1, InternalField_3273, InternalField_3272, layerMask);

            bool InternalVar_2 = InternalField_3272.Count > 0;

            bool InternalVar_3 = false;
            bool InternalVar_4 = false;
            UIBlockHit InternalVar_5 = default;
            bool InternalVar_6 = false;

            if (InternalVar_2)
            {
                InternalVar_6 = InternalField_3274.InternalMethod_502<bool>(controlID, out InternalVar_5);
                bool2 InternalVar_7 = InternalMethod_2992<bool>(InternalField_3272, InternalParameter_2418: InternalVar_5.UIBlock);

                InternalVar_3 = InternalVar_7.x;
                InternalVar_4 = InternalVar_7.y;

                if (InternalVar_3 && !InternalVar_4 && InternalVar_6)
                {
                    Plane InternalVar_8 = new Plane(InternalVar_5.Normal, InternalVar_5.Position);
                    Vector3 InternalVar_9 = InternalVar_8.ClosestPointOnPlane(InternalVar_1.InternalField_1663);
                    InternalVar_4 = Vector3.Distance(InternalVar_9, InternalVar_1.InternalField_1663) <= InternalVar_1.InternalField_1664;
                }
            }

            bool InternalVar_10 = false;
            if (!InternalVar_3 && (InternalVar_6 || InternalField_3274.InternalMethod_502<bool>(controlID, out InternalVar_5)))
            {
                Plane InternalVar_11 = new Plane(InternalVar_5.Normal, InternalVar_5.Position);
                Vector3 InternalVar_12 = InternalVar_11.ClosestPointOnPlane(InternalVar_1.InternalField_1663);

                if (InternalVar_11.GetSide(InternalVar_1.InternalField_1663)) 
                {
                    InternalField_3272.Add(new UIBlockHit() { UIBlock = InternalVar_5.UIBlock, Position = InternalVar_12, Normal = InternalVar_5.Normal });
                    InternalVar_3 = true;
                    InternalVar_4 = true;
                }
                else  
                {
                    float InternalVar_13 = Vector3.Distance(InternalVar_1.InternalField_1663, InternalVar_12);

                    if (InternalVar_13 <= InternalVar_1.InternalField_1664)
                    {
                        UIBlock InternalVar_14 = InternalVar_5.UIBlock.Root;

                        Bounds InternalVar_15 = new Bounds(InternalVar_14.InternalProperty_21, InternalVar_14.InternalProperty_20 + (Vector3.one * 2 * InternalType_187.InternalField_494));
                        Vector3 InternalVar_16 = InternalType_187.InternalMethod_3642(InternalVar_14.transform.InverseTransformPoint(InternalVar_12));

                        if (InternalVar_15.Contains(InternalVar_16))
                        {
                            InternalField_3272.Add(new UIBlockHit() { UIBlock = InternalVar_5.UIBlock, Position = InternalVar_12, Normal = InternalVar_5.Normal });
                            InternalVar_2 = true;
                        }
                    }
                    else if (InternalVar_13 > InternalVar_1.InternalField_1664 * InternalField_3301)
                    {
                        InternalVar_10 = true;
                    }
                }
            }

            Vector3 InternalVar_17 = InternalField_3272.Count > 0 ? (InternalField_3272[0].Position - sphere.Center).normalized : Vector3.zero;

            Ray InternalVar_18 = new Ray(sphere.Center - InternalVar_17 * sphere.Radius, InternalVar_17);
            Update InternalVar_19 = new Update(InternalVar_18, controlID, userData);

            if (InternalVar_10)
            {
                InternalField_3274.InternalMethod_501(InternalVar_19.InternalMethod_2204());
            }
            else
            {
                bool InternalVar_20 = InternalVar_2 && (InternalVar_3 == InternalVar_4) && InternalField_3272.Count > 0;

                InternalMethod_3007(ref InternalVar_19, InternalField_3272, InternalParameter_2887: InternalVar_20, InternalType_85.InternalField_285, InternalParameter_2420: accuracy == InputAccuracy.Low);
            }
        }

        /// <summary>
        /// Performs a raycast with the provided <see cref="Update.Ray"/> and routes the <paramref name="update"/> update to the collided <see cref="UIBlock"/> or the <see cref="UIBlock"/> currently capturing the active interaction.
        /// </summary>
        /// <remarks>Point updates are only delivered to <see cref="UIBlock"/>s with an attached <see cref="Interactable"/> or <see cref="Scroller"/> component.</remarks>
        /// <param name="update">The data tied to this interaction update. <see cref="Update.Ray"/> is in world space.</param>
        /// <param name="pointerDown">A flag to indicate the "pressed" state of the control represented by <see cref="Update.ControlID"/>.</param>
        /// <param name="allowDrag">A flag to indicate whether or not this call to <see cref="Point(Update, bool, bool, float, int, InputAccuracy)"/> can trigger or update an <see cref="Gesture.OnDrag"/> event.</param>
        /// <param name="maxDistance">The max distance from the ray origin (in world space) to consider an intersection point a "hit".</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <param name="accuracy">The accuracy of the input source, defaults to <see cref="InputAccuracy.High"/>.</param>
        /// <seealso cref="Point(Sphere, uint, object, int, InputAccuracy)"/>
        /// <seealso cref="Raycast(Ray, out UIBlockHit, float, int)"/>
        /// <seealso cref="RaycastAll(Ray, List{UIBlockHit}, float, int)"/>
        /// <seealso cref="SphereCollide(Sphere, out UIBlockHit, int)"/>
        /// <seealso cref="SphereCollideAll(Sphere, List{UIBlockHit}, int)"/>
        /// <seealso cref="Cancel(Update)"/>
        public static void Point(Update update, bool pointerDown, bool allowDrag = true, float maxDistance = float.PositiveInfinity, int layerMask = AllLayers, InputAccuracy accuracy = InputAccuracy.High)
        {
            InternalType_85 InternalVar_1 = pointerDown ? InternalType_85.InternalField_1162 : InternalType_85.InternalField_284;
            InternalMethod_3008<bool>(update, maxDistance, layerMask, InternalField_3272, InternalVar_1);

            InternalType_85 InternalVar_2 = allowDrag ? InternalType_85.InternalField_285 : InternalType_85.InternalField_1162;
            InternalMethod_3007(ref update, InternalField_3272, pointerDown, InternalVar_2, InternalParameter_2420: accuracy == InputAccuracy.Low);
        }

        /// <summary>
        /// Performs a raycast with the provided <see cref="Update.Ray"/> and routes the <paramref name="scroll"/> update to the collided <see cref="UIBlock"/>.
        /// </summary>
        /// <remarks>Scroll updates are only delivered to <see cref="UIBlock"/>s with an attached <see cref="Scroller"/> component.</remarks>
        /// <param name="update">The data tied to this interaction update. <see cref="Update.Ray"/> is in world space.</param>
        /// <param name="scroll">A normalized scroll vector</param>
        /// <param name="maxDistance">The max distance from the ray origin (in world space) to consider an intersection point a "hit".</param>
        /// <param name="layerMask">The gameobject layers to include, defaults to "All Layers".</param>
        /// <param name="accuracy">The accuracy of the input source, defaults to <see cref="InputAccuracy.High"/>.</param>
        public static void Scroll(Update update, Vector3 scroll, float maxDistance = float.PositiveInfinity, int layerMask = AllLayers, InputAccuracy accuracy = InputAccuracy.High)
        {
            InternalMethod_3008<InternalType_755<Vector3>>(update, maxDistance, layerMask, InternalField_3272, InternalType_85.InternalField_284);
            InternalMethod_3007(ref update, InternalField_3272, new InternalType_755<Vector3>(ref scroll), InternalType_85.InternalField_284, InternalParameter_2420: accuracy == InputAccuracy.Low);
        }

        /// <summary>
        /// Cancel the most recent/current gesture triggered by the input control mapped to <paramref name="update"/>.<see cref="Update.ControlID">ControlID</see>.
        /// </summary>
        /// <param name="update">The data tied to this interaction update. <see cref="Update.Ray"/> is in world space.</param>
        public static void Cancel(Update update)
        {
            InternalField_3274.InternalMethod_501(update.InternalMethod_2204());
        }

        /// <summary>
        /// Cancel the recent/current gesture triggered by the input control mapped to <paramref name="controlID"/>.
        /// </summary>
        /// <param name="controlID">The unique identifier of the input control whose gesture the caller wishes to cancel.</param>
        public static void Cancel(uint controlID = 0)
        {
            InternalField_3274.InternalMethod_501(new InternalNamespace_0.InternalType_78(controlID));
        }

        #region 
        private static void InternalMethod_3195(InternalType_432 InternalParameter_3027, List<InternalType_428> InternalParameter_3026, List<UIBlockHit> InternalParameter_2944, int InternalParameter_2943)
        {
            InternalParameter_3026.Clear();
            InternalParameter_2944.Clear();

            InternalType_429.InternalProperty_200.InternalMethod_1689(InternalParameter_3027, InternalParameter_3026, InternalParameter_2943);

            for (int InternalVar_1 = 0; InternalVar_1 < InternalParameter_3026.Count; ++InternalVar_1)
            {
                InternalType_428 InternalVar_2 = InternalParameter_3026[InternalVar_1];

                InternalParameter_2944.Add(new UIBlockHit()
                {
                    UIBlock = InternalVar_2.InternalField_1642 as UIBlock,
                    Position = InternalVar_2.InternalField_1643,
                    Normal = InternalVar_2.InternalField_1644,
                });
            }
        }

        private static bool InternalMethod_3009(Ray InternalParameter_2942, List<InternalType_428> InternalParameter_2941, List<UIBlockHit> InternalParameter_2940, float InternalParameter_2939, int InternalParameter_2938)
        {
            InternalParameter_2941.Clear();
            InternalParameter_2940.Clear();
            InternalType_429.InternalProperty_200.InternalMethod_1686(InternalParameter_2942, InternalParameter_2941, InternalParameter_2939, InternalParameter_2938);

            for (int InternalVar_1 = 0; InternalVar_1 < InternalParameter_2941.Count; ++InternalVar_1)
            {
                InternalType_428 InternalVar_2 = InternalParameter_2941[InternalVar_1];

                InternalParameter_2940.Add(new UIBlockHit()
                {
                    UIBlock = InternalVar_2.InternalField_1642 as UIBlock,
                    Position = InternalVar_2.InternalField_1643,
                    Normal = InternalVar_2.InternalField_1644
                });
            }

            return InternalParameter_2940.Count > 0;
        }

        
        private static void InternalMethod_3008<TInput>(Update InternalParameter_2937, float InternalParameter_2893, int InternalParameter_2892, List<UIBlockHit> InternalParameter_2891, InternalType_85 InternalParameter_2890) where TInput : unmanaged, System.IEquatable<TInput>
        {
            uint InternalVar_1 = InternalParameter_2937.ControlID;
            if (InternalVar_1 < 0 || InternalVar_1 >= InputRouter.InternalField_2940)
            {
                throw new System.ArgumentException($"Invalid Control ID [{InternalVar_1}]. Expected within range [0, {InputRouter.InternalField_2940}]");
            }

            if (InternalMethod_3009(InternalParameter_2937.Ray, InternalField_3273, InternalParameter_2891, InternalParameter_2893, InternalParameter_2892))
            {
                _ = InternalMethod_2992<TInput>(InternalParameter_2891);
            }

            if (InternalParameter_2891.Count > 0 || InternalParameter_2890 == InternalType_85.InternalField_284)
            {
                return;
            }

            if (!InternalField_3274.InternalMethod_502<TInput>(InternalVar_1, out UIBlockHit InternalVar_2))
            {
                return;
            }

            Plane InternalVar_3 = new Plane(InternalVar_2.Normal, InternalVar_2.Position);
            Vector3 InternalVar_4 = InternalVar_2.Position;

            if (InternalVar_3.Raycast(InternalParameter_2937.Ray, out float InternalVar_5))
            {
                InternalVar_4 = InternalParameter_2937.Ray.GetPoint(InternalType_187.InternalMethod_869(InternalVar_5, InternalParameter_2893));
            }

            InternalParameter_2891.Add(new UIBlockHit() { Normal = InternalVar_3.normal, Position = InternalVar_4, UIBlock = InternalVar_2.UIBlock });
        }

        
        private static void InternalMethod_3007<TInput>(ref Update InternalParameter_2889, List<UIBlockHit> InternalParameter_2888, TInput InternalParameter_2887, InternalType_85 InternalParameter_2421, bool InternalParameter_2420) where TInput : unmanaged, System.IEquatable<TInput>
        {
            InternalField_3274.InternalMethod_2056(InternalParameter_2889.InternalMethod_2204(), InternalParameter_2887, InternalParameter_2693: InternalParameter_2888.InternalMethod_2043(), InternalParameter_2421, InternalParameter_2420);
        }

        private static bool2 InternalMethod_2992<T>(List<UIBlockHit> InternalParameter_2419, UIBlock InternalParameter_2418 = null) where T : unmanaged, System.IEquatable<T>
        {
            bool InternalVar_1 = false;

            for (int InternalVar_2 = InternalParameter_2419.Count - 1; InternalVar_2 >= 0; --InternalVar_2)
            {
                UIBlockHit InternalVar_3 = InternalParameter_2419[InternalVar_2];

                if (!InternalVar_3.UIBlock.InternalMethod_82<T>())
                {
                    InternalParameter_2419.RemoveAt(InternalVar_2);
                    continue;
                }

                InternalVar_1 |= InternalVar_3.UIBlock == InternalParameter_2418;

                if (InternalVar_2 < InternalParameter_2419.Count - 1)
                {
                    InternalType_75 InternalVar_4 = InternalVar_3.UIBlock.InternalProperty_23.InternalProperty_1149;

                    if (InternalVar_4 != null && InternalVar_4.InternalProperty_741)
                    {
                        InternalParameter_2419.RemoveRange(InternalVar_2 + 1, InternalParameter_2419.Count - InternalVar_2 - 1);
                    }
                }
            }

            return new bool2(InternalParameter_2419.Count > 0, InternalVar_1 && InternalParameter_2418 != null);
        }

        private static InternalType_521<UIBlockHit> InternalMethod_2991<T>(List<UIBlockHit> InternalParameter_2417) where T : unmanaged, System.IEquatable<T>
        {
            UIBlockHit InternalVar_1 = default;

            for (int InternalVar_2 = 0; InternalVar_2 < InternalParameter_2417.Count; ++InternalVar_2)
            {
                UIBlockHit InternalVar_3 = InternalParameter_2417[InternalVar_2];

                if (InternalVar_3.UIBlock.InternalMethod_82<T>())
                {
                    InternalVar_1 = InternalVar_3;
                    break;
                }
            }

            InternalParameter_2417.Clear();

            if (InternalVar_1.UIBlock != null)
            {
                InternalParameter_2417.Add(InternalVar_1);
            }

            return InternalParameter_2417.InternalMethod_2043();
        }
        #endregion
    }
}
