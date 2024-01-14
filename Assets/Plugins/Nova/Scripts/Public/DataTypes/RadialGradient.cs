// Copyright (c) Supernova Technologies LLC
using System;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A radial gradient to blend with the body color of a parent element.
    /// </summary>
    /// <seealso cref="UIBlock2D.Gradient"/>
    [Serializable]
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct RadialGradient : IEquatable<RadialGradient>
    {
        /// <summary>
        /// The color of the gradient to blend with the body color of its parent element.
        /// </summary>
        [SerializeField]
        public Color Color;
        /// <summary>
        /// The <see cref="Length2"/> configuration for the center position of the gradient in its parent element's local space.
        /// </summary>
        [SerializeField]
        public Length2 Center;
        /// <summary>
        /// A <see cref="Length2"/> configuration for the radii along the gradient's X and Y axes, determines the gradient's size. 
        /// </summary>
        /// <remarks>
        /// Setting a radius to <c>0</c> is equivalent to setting the radius to <c>float.PositiveInfinity</c> and
        /// can be used to achieve a linear-style gradient.
        /// </remarks>
        [SerializeField]
        public Length2 Radius;
        /// <summary>
        /// The counter-clockwise rotation of the gradient (in degrees) around its <see cref="Center"/>.
        /// </summary>
        [SerializeField]
        public float Rotation;
        /// <summary>
        /// A flag to toggle the gradient's visibility.
        /// </summary>
        [SerializeField]
        public bool Enabled;

        public static bool operator ==(RadialGradient lhs, RadialGradient rhs)
        {
            return
                lhs.Color.Equals(rhs.Color) &&
                lhs.Center.Equals(rhs.Center) &&
                lhs.Radius.Equals(rhs.Radius) &&
                lhs.Rotation.Equals(rhs.Rotation) &&
                lhs.Enabled.Equals(rhs.Enabled);
        }
        public static bool operator !=(RadialGradient lhs, RadialGradient rhs) => !(rhs == lhs);

        /// <summary>
        /// Constructs a new <see cref="RadialGradient"/>.
        /// </summary>
        /// <param name="color"></param>
        /// <param name="center"></param>
        /// <param name="radius"></param>
        /// <param name="rotation"></param>
        /// <param name="enabled"></param>
        public RadialGradient(Color color, Length2 center, Length2 radius, float rotation = 0f, bool enabled = true)
        {
            Color = color;
            Center = center;
            Radius = radius;
            Rotation = rotation;
            Enabled = enabled;
        }

        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Color.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Center.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Radius.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Rotation.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Enabled.GetHashCode();
            return InternalVar_1;
        }

        public override bool Equals(object other)
        {
            if (other is RadialGradient asType)
            {
                return this == asType;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="RadialGradient"/> to compare.</param>
        /// <returns><see langword="true"/> if <c>this == <paramref name="other"/></c></returns>
        public bool Equals(RadialGradient other) => this == other;

        /// <summary>
        /// The string representation of this <see cref="RadialGradient"/>.
        /// </summary>
        public override string ToString()
        {
            if (!Enabled)
            {
                return "Disabled";
            }

            return $"Color = {Color}, Radius = {Radius}";
        }

        internal Calculated InternalMethod_145(Vector2 InternalParameter_86)
        {
            return new Calculated(this, InternalParameter_86);
        }

        [Obfuscation]
        internal readonly struct Calculated
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Length2.Calculated Center;
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public readonly Length2.Calculated Radius;

            internal Calculated(RadialGradient gradient, Vector2 relativeTo)
            {
                var InternalVar_1 = InternalNamespace_0.InternalType_48.InternalMethod_365(gradient.Center.InternalMethod_2(), InternalNamespace_0.InternalType_48.InternalType_49.InternalField_161, relativeTo);
                Center = InternalVar_1.InternalMethod_19();

                var InternalVar_2 = InternalNamespace_0.InternalType_48.InternalMethod_365(gradient.Radius.InternalMethod_2(), InternalNamespace_0.InternalType_48.InternalType_49.InternalField_162, relativeTo);
                Radius = InternalVar_2.InternalMethod_19();
            }
        }

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal static readonly RadialGradient InternalField_57 = new RadialGradient()
        {
            Enabled = false,
            Color = Color.white,
            Center = new Length2(Length.Percentage(0f), Length.Percentage(0f)),
            Radius = new Length2(Length.Percentage(0.5f), Length.Percentage(0.5f)),
            Rotation = 0f,
        };
    }
}