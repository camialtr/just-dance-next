// Copyright (c) Supernova Technologies LLC
using System;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// Defines the behavior of an element when it's selected.
    /// </summary>
    public enum SelectBehavior
    {
        /// <summary>
        /// Treat Select events as click events.
        /// </summary>
        Click,

        /// <summary>
        /// Push the selected element onto the selection stack and convert
        /// subsequent navigation move input into corresponding directed input
        /// events until the element is deselected.
        /// </summary>
        FireEvents,

        /// <summary>
        /// Push the selected element onto the selection stack and scope
        /// subsequent navigation events to this element's descendant hierarchy
        /// until it's deselected.
        /// </summary>
        ScopeNavigation
    }

    /// <summary>
    /// Defines a <see cref="NavLink"/> for each axis-aligned direction.
    /// </summary>
    [Serializable]
    public struct NavNode : IEquatable<NavNode>
    {
        /// <summary>
        /// A <see cref="NavNode"/> where all X/Y <see cref="NavLink"/>s are set to <see cref="NavLink.Auto"/> and Z <see cref="NavLink"/>s are set to <see cref="NavLink.Empty"/>.
        /// </summary>
        public static readonly NavNode TwoD = new NavNode()
        {
            Left = NavLink.Auto,
            Right = NavLink.Auto,
            Down = NavLink.Auto,
            Up = NavLink.Auto,
            Forward = NavLink.Empty,
            Back = NavLink.Empty
        };

        /// <summary>
        /// The <see cref="NavLink"/> to use when navigating to the left of this <see cref="NavNode"/>.
        /// </summary>
        [SerializeField]
        public NavLink Left;
        /// <summary>
        /// The <see cref="NavLink"/> to use when navigating to the right of this <see cref="NavNode"/>.
        /// </summary>
        [SerializeField]
        public NavLink Right;
        /// <summary>
        /// The <see cref="NavLink"/> to use when navigating downward from this <see cref="NavNode"/>.
        /// </summary>
        [SerializeField]
        public NavLink Down;
        /// <summary>
        /// The <see cref="NavLink"/> to use when navigating upward from this <see cref="NavNode"/>.
        /// </summary>
        [SerializeField]
        public NavLink Up;
        /// <summary>
        /// The <see cref="NavLink"/> to use when navigating forward from this <see cref="NavNode"/>.
        /// </summary>
        [SerializeField]
        public NavLink Forward;
        /// <summary>
        /// The <see cref="NavLink"/> to use when navigating backward from this <see cref="NavNode"/>.
        /// </summary>
        [SerializeField]
        public NavLink Back;

        /// <summary>
        /// Converts the provided <paramref name="direction"/> into the nearest axis-aligned 
        /// direction (e.g. Left, Down, Forward, etc.) and returns the <see cref="NavLink"/>
        /// corresponding to that axis-aligned direction.
        /// </summary>
        /// <param name="direction">The approximate direction vector of the desired <see cref="NavLink"/> to retrieve.</param>
        /// <returns>The <see cref="NavLink"/> in the given <paramref name="direction"/>.</returns>
        public NavLink GetLink(Vector3 direction)
        {
            NavLink InternalVar_1 = default;

            if (direction == Vector3.left)
            {
                InternalVar_1 = Left;
            }
            else if (direction == Vector3.down)
            {
                InternalVar_1 = Down;
            }
            else if (direction == Vector3.back)
            {
                InternalVar_1 = Back;
            }
            else if (direction == Vector3.right)
            {
                InternalVar_1 = Right;
            }
            else if (direction == Vector3.up)
            {
                InternalVar_1 = Up;
            }
            else if (direction == Vector3.forward)
            {
                InternalVar_1 = Forward;
            }
            else
            {
                float InternalVar_2 = Mathf.Atan(direction.y / direction.z) * Mathf.Rad2Deg;

                if (InternalVar_2 <= 45 && InternalVar_2 >= -45)
                {
                    InternalVar_1 = Forward;
                }
                else if (InternalVar_2 >= 135 || InternalVar_2 <= -135)
                {
                    InternalVar_1 = Back;
                }
                else
                {
                    switch (Mathf.Atan(direction.y / direction.x) * Mathf.Rad2Deg)
                    {
                        case float angle when angle < 45 && angle >= -45:
                            InternalVar_1 = Right;
                            break;
                        case float angle when angle < 135 && angle >= 45:
                            InternalVar_1 = Up;
                            break;
                        case float angle when angle < -135 || angle >= 135:
                            InternalVar_1 = Left;
                            break;
                        case float angle when angle < -45 && angle >= -135:
                            InternalVar_1 = Down;
                            break;
                    }
                }
            }

            return InternalVar_1;
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><c>true</c> if all fields of <paramref name="lhs"/> are equal to their respective fields of <paramref name="rhs"/>.</returns>
        public static bool operator ==(NavNode lhs, NavNode rhs)
        {
            return lhs.Left == rhs.Left &&
                   lhs.Right == rhs.Right &&
                   lhs.Down == rhs.Down &&
                   lhs.Up == rhs.Up &&
                   lhs.Forward == rhs.Forward &&
                   lhs.Back == rhs.Back;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns><c>true</c> if any fields of <paramref name="lhs"/> are <b>not</b> equal to their respective fields of <paramref name="rhs"/>.</returns>
        public static bool operator !=(NavNode lhs, NavNode rhs)
        {
            return lhs.Left != rhs.Left ||
                   lhs.Right != rhs.Right ||
                   lhs.Down != rhs.Down ||
                   lhs.Up != rhs.Up ||
                   lhs.Forward != rhs.Forward ||
                   lhs.Back != rhs.Back;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="NavNode"/> to compare.</param>
        /// <returns><c>true</c> if <c>this == <paramref name="other"/></c>.</returns>
        public bool Equals(NavNode other)
        {
            return this == other;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The <see cref="NavNode"/> to compare.</param>
        /// <returns><c>true</c> if <c>this == <paramref name="other"/></c>.</returns>
        public override bool Equals(object other)
        {
            return other is NavNode node && Equals(node);
        }

        /// <summary>The hashcode for this <see cref="NavNode"/></summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;

            InternalVar_1 = (InternalVar_1 * 7) + Left.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Right.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Down.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Up.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Forward.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Back.GetHashCode();

            return InternalVar_1;
        }
    }

    internal static class InternalType_741
    {
        public static bool InternalMethod_2715(ref this NavNode InternalParameter_3172, Vector3 InternalParameter_3173, out InternalType_5 InternalParameter_3174)
        {
            InternalParameter_3174 = null;

            NavLink InternalVar_1 = InternalParameter_3172.GetLink(InternalParameter_3173);

            if (InternalVar_1.InternalMethod_2716(out UIBlock InternalVar_2))
            {
                InternalParameter_3174 = InternalVar_2;
            }

            return InternalVar_1.Type == NavLinkType.Manual;
        }
    }
}
