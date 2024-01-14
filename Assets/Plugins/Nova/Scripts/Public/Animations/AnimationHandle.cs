// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_1;
using System;

namespace Nova
{
    /// <summary>
    /// A unique identifier of a scheduled <see cref="IAnimation"/>, <see cref="IAnimationWithEvents"/>, or any sequence/combination of the two
    /// </summary>
    /// <remarks>
    /// <list type="table">
    /// <item><term>Chain</term> <description><see cref="AnimationHandleExtensions.Chain{T}(AnimationHandle, T, float, int)"/></description></item>
    /// <item><term>Include</term> <description><see cref="AnimationHandleExtensions.Include{T}(AnimationHandle, T)"/></description></item>
    /// <item><term>Pause</term> <description><see cref="AnimationHandleExtensions.Pause(AnimationHandle)"/></description></item>
    /// <item><term>Resume</term> <description><see cref="AnimationHandleExtensions.Resume(AnimationHandle)"/></description></item>
    /// <item><term>Cancel</term> <description><see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/></description></item>
    /// <item><term>Complete</term> <description><see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/></description></item>
    /// </list>
    /// </remarks>
    public readonly struct AnimationHandle : IEquatable<AnimationHandle>
    {
        /// <summary>
        /// A constant value used to indicate a single animation iteration
        /// </summary>
        public const int Once = 1;

        /// <summary>
        /// A constant value used to indicate an indefinitely looping animation
        /// </summary>
        public const int Infinite = -1;

        [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
        internal readonly InternalType_125 InternalField_2977;

        private AnimationHandle(InternalType_125 InternalParameter_2250)
        {
            InternalField_2977 = InternalParameter_2250;
        }

        internal static AnimationHandle InternalMethod_2692(InternalType_125 InternalParameter_2249)
        {
            return new AnimationHandle(InternalParameter_2249);
        }

        /// <summary>
        /// Equality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if lhs and rhs are equal</returns>
        public static bool operator ==(AnimationHandle lhs, AnimationHandle rhs)
        {
            return lhs.InternalField_2977.Equals(rhs.InternalField_2977);
        }

        /// <summary>
        /// Inequality operator
        /// </summary>
        /// <param name="lhs">Left hand side</param>
        /// <param name="rhs">Right hand side</param>
        /// <returns><see langword="true"/> if lhs and rhs are <b>not</b> equal</returns>
        public static bool operator !=(AnimationHandle lhs, AnimationHandle rhs)
        {
            return !lhs.InternalField_2977.Equals(rhs.InternalField_2977);
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="AnimationHandle"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == other</c></returns>
        public override bool Equals(object pther)
        {
            if (pther is AnimationHandle handle)
            {
                return InternalField_2977.Equals(handle.InternalField_2977);
            }
            return false;
        }

        /// <summary>
        /// Get the hashcode for this <see cref="AnimationHandle"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return InternalField_2977.GetHashCode();
        }

        /// <summary>
        /// Equality compare
        /// </summary>
        /// <param name="other">The other <see cref="AnimationHandle"/> to compare</param>
        /// <returns><see langword="true"/> if <c>this == other</c></returns>
        public bool Equals(AnimationHandle other)
        {
            return InternalField_2977.Equals(other.InternalField_2977);
        }
    }
}
