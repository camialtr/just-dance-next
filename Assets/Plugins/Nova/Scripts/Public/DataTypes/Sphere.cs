// Copyright (c) Supernova Technologies LLC
using UnityEngine;

namespace Nova
{
    /// <summary>
    /// A sphere represented by a center position and radius.
    /// </summary>
    /// <seealso cref="Interaction.Point(Sphere, uint, object, int, InputAccuracy)"/>
    public struct Sphere : System.IEquatable<Sphere>
    {
        /// <summary>
        /// The center position of the sphere.
        /// </summary>
        public Vector3 Center;

        /// <summary>
        /// The radius of the sphere.
        /// </summary>
        public float Radius;

        /// <summary>
        /// Create a new sphere from a center position and radius.
        /// </summary>
        /// <param name="center">The center position of the sphere, <see cref="Center"/>.</param>
        /// <param name="radius">The radius of the sphere, <see cref="Radius"/>.</param>
        public Sphere(Vector3 center, float radius)
        {
            Center = center;
            Radius = radius;
        }

#if PHYSICS
        /// <summary>
        /// Create a <see cref="Sphere"/> in world space from a <see cref="SphereCollider"/>.
        /// </summary>
        /// <remarks>Because the new <see cref="Sphere"/> is in world space, this constructor reads from <paramref name="collider"/>.<see cref="Collider.bounds">bounds</see>.</remarks>
        /// <param name="collider">The collider to read from.</param>
        public Sphere(SphereCollider collider)
        {
            if (collider == null)
            {
                Center = Vector3.zero;
                Radius = 0;
                return;
            }

            Bounds bounds = collider.bounds;
            Center = bounds.center;
            Radius = Unity.Mathematics.math.cmax(bounds.extents);
        }

        /// <summary>
        /// Create a <see cref="Sphere"/> in world space from a <see cref="SphereCollider"/>.
        /// </summary>
        /// <remarks>Because the new <see cref="Sphere"/> is in world space, this operator reads from <paramref name="collider"/>.<see cref="Collider.bounds">bounds</see>.</remarks>
        /// <param name="collider">The collider to read from.</param>
        public static implicit operator Sphere(SphereCollider collider)
        {
            return new Sphere(collider);
        }
#endif

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if <c><paramref name="lhs"/>.Center == <paramref name="rhs"/>.Center &amp;&amp; <paramref name="lhs"/>.Radius == <paramref name="rhs"/>.Radius</c>.
        /// </returns>
        public static bool operator ==(Sphere lhs, Sphere rhs)
        {
            return lhs.Center == rhs.Center && lhs.Radius == rhs.Radius;
        }

        /// <summary>
        /// Inequality operator.
        /// </summary>
        /// <param name="lhs">Left hand side.</param>
        /// <param name="rhs">Right hand side.</param>
        /// <returns>
        /// <see langword="true"/> if <c><paramref name="lhs"/>.Center != <paramref name="rhs"/>.Center || <paramref name="lhs"/>.Radius != <paramref name="rhs"/>.Radius</c>.
        /// </returns>
        public static bool operator !=(Sphere lhs, Sphere rhs)
        {
            return lhs.Center != rhs.Center || lhs.Radius != rhs.Radius;
        }

        /// <summary>
        /// The hashcode for this <see cref="Sphere"/>.
        /// </summary>
        public override int GetHashCode()
        {
            int InternalVar_1 = 13;
            InternalVar_1 = (InternalVar_1 * 7) + Center.GetHashCode();
            InternalVar_1 = (InternalVar_1 * 7) + Radius.GetHashCode();
            return InternalVar_1;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="Sphere"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if <c>this == <paramref name="other"/>.</c>
        /// </returns>
        public override bool Equals(object other)
        {
            if (other is Sphere sphere)
            {
                return this == sphere;
            }

            return false;
        }

        /// <summary>
        /// Equality compare.
        /// </summary>
        /// <param name="other">The other <see cref="Sphere"/> to compare.</param>
        /// <returns>
        /// <see langword="true"/> if <c>this == <paramref name="other"/></c>.
        /// </returns>
        public bool Equals(Sphere other)
        {
            return this == other;
        }

        /// <summary>
        /// The string representation of this <see cref="Sphere"/>.
        /// </summary>
        public override string ToString()
        {
            return $"Center = {Center}, Radius = {Radius}";
        }
    }
}
