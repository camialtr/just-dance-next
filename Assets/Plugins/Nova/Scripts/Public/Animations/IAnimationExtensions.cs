// Copyright (c) Supernova Technologies LLC
using System;

namespace Nova
{
    /// <summary>
    /// A set of extension methods to schedule <see cref="IAnimationWithEvents"/>
    /// </summary>
    /// <seealso cref="IAnimationExtensions"/>
    /// <seealso cref="AnimationHandleExtensions"/>
    /// <seealso cref="AnimationHandleWithEventsExtensions"/>
    public static class IAnimationWithEventsExtensions
    {
        /// <summary>
        /// Queue an animation to run for <paramref name="durationInSeconds"/> starting at the end of the current frame.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="animation"/> struct</typeparam>
        /// <param name="animation">The <see cref="IAnimation"/> struct configured to perform the animation via <see cref="IAnimation.Update(float)"/></param>
        /// <param name="durationInSeconds">The duration, in seconds, of the animation</param>
        /// <returns>An <see cref="AnimationHandle"/>, which can be used to: 
        /// <list type="table">
        /// <item><term>Chain</term> <description><see cref="AnimationHandleExtensions.Chain{T}(AnimationHandle, T, float, int)"/></description></item>
        /// <item><term>Include</term> <description><see cref="AnimationHandleExtensions.Include{T}(AnimationHandle, T)"/></description></item>
        /// <item><term>Pause</term> <description><see cref="AnimationHandleExtensions.Pause(AnimationHandle)"/></description></item>
        /// <item><term>Resume</term> <description><see cref="AnimationHandleExtensions.Resume(AnimationHandle)"/></description></item>
        /// <item><term>Cancel</term> <description><see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/></description></item>
        /// <item><term>Complete</term> <description><see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/></description></item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="durationInSeconds"/> is invalid.</exception>
        public static AnimationHandle Run<T>(this T animation, float durationInSeconds) where T : struct, IAnimationWithEvents
        {
            IAnimationExtensions.InternalMethod_2751(durationInSeconds);

            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2950(ref animation, durationInSeconds, AnimationHandle.Once));
        }

        /// <summary>
        /// Queue an animation to loop <paramref name="iterations"/> times for <paramref name="durationInSeconds"/> per iteration, where <c><paramref name="iterations"/> == -1</c> indicates "until canceled", starting at the end of the current frame.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="animation"/> struct</typeparam>
        /// <param name="animation">The <see cref="IAnimation"/> struct configured to perform the animation via <see cref="IAnimation.Update(float)"/></param>
        /// <param name="durationInSeconds">The duration, in seconds, per iteration of the animation</param>
        /// <param name="iterations">The number of iterations to perform before the animation is removed from the animation queue. <c>-1</c> indicates "infinite iterations"</param>
        /// <returns>An <see cref="AnimationHandle"/>, which can be used to: 
        /// <list type="table">
        /// <item><term>Chain</term> <description><see cref="AnimationHandleExtensions.Chain{T}(AnimationHandle, T, float, int)"/></description></item>
        /// <item><term>Include</term> <description><see cref="AnimationHandleExtensions.Include{T}(AnimationHandle, T)"/></description></item>
        /// <item><term>Pause</term> <description><see cref="AnimationHandleExtensions.Pause(AnimationHandle)"/></description></item>
        /// <item><term>Resume</term> <description><see cref="AnimationHandleExtensions.Resume(AnimationHandle)"/></description></item>
        /// <item><term>Cancel</term> <description><see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/></description></item>
        /// <item><term>Complete</term> <description><see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/></description></item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="durationInSeconds"/> is invalid.</exception>
        public static AnimationHandle Loop<T>(this T animation, float durationInSeconds, int iterations = AnimationHandle.Infinite) where T : struct, IAnimationWithEvents
        {
            IAnimationExtensions.InternalMethod_2751(durationInSeconds);

            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2950(ref animation, durationInSeconds, iterations));
        }
    }

    /// <summary>
    /// A set of extension methods to schedule <see cref="IAnimation"/>s
    /// </summary>
    /// <seealso cref="IAnimationWithEventsExtensions"/>
    /// <seealso cref="AnimationHandleExtensions"/>
    /// <seealso cref="AnimationHandleWithEventsExtensions"/>
    public static class IAnimationExtensions
    {
        /// <summary>
        /// Queue an animation to run for <paramref name="durationInSeconds"/> starting at the end of the current frame.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="animation"/> struct</typeparam>
        /// <param name="animation">The <see cref="IAnimation"/> struct configured to perform the animation via <see cref="IAnimation.Update(float)"/></param>
        /// <param name="durationInSeconds">The duration, in seconds, of the animation</param>
        /// <returns>An <see cref="AnimationHandle"/>, which can be used to: 
        /// <list type="table">
        /// <item><term>Chain</term> <description><see cref="AnimationHandleExtensions.Chain{T}(AnimationHandle, T, float, int)"/></description></item>
        /// <item><term>Include</term> <description><see cref="AnimationHandleExtensions.Include{T}(AnimationHandle, T)"/></description></item>
        /// <item><term>Pause</term> <description><see cref="AnimationHandleExtensions.Pause(AnimationHandle)"/></description></item>
        /// <item><term>Resume</term> <description><see cref="AnimationHandleExtensions.Resume(AnimationHandle)"/></description></item>
        /// <item><term>Cancel</term> <description><see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/></description></item>
        /// <item><term>Complete</term> <description><see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/></description></item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="durationInSeconds"/> is invalid.</exception>
        public static AnimationHandle Run<T>(this T animation, float durationInSeconds) where T : struct, IAnimation
        {
            IAnimationExtensions.InternalMethod_2751(durationInSeconds);

            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2949(ref animation, durationInSeconds, AnimationHandle.Once));
        }

        /// <summary>
        /// Queue an animation to loop <paramref name="iterations"/> times for <paramref name="durationInSeconds"/> per iteration, where <c><paramref name="iterations"/> == -1</c> indicates "until canceled", starting at the end of the current frame.
        /// </summary>
        /// <typeparam name="T">The type of the <paramref name="animation"/> struct</typeparam>
        /// <param name="animation">The <see cref="IAnimation"/> struct configured to perform the animation via <see cref="IAnimation.Update(float)"/></param>
        /// <param name="durationInSeconds">The duration, in seconds, per iteration of the animation</param>
        /// <param name="iterations">The number of iterations to perform before the animation is removed from the animation queue. <c>-1</c> indicates "infinite iterations"</param>
        /// <returns>An <see cref="AnimationHandle"/>, which can be used to: 
        /// <list type="table">
        /// <item><term>Chain</term> <description><see cref="AnimationHandleExtensions.Chain{T}(AnimationHandle, T, float, int)"/></description></item>
        /// <item><term>Include</term> <description><see cref="AnimationHandleExtensions.Include{T}(AnimationHandle, T)"/></description></item>
        /// <item><term>Pause</term> <description><see cref="AnimationHandleExtensions.Pause(AnimationHandle)"/></description></item>
        /// <item><term>Resume</term> <description><see cref="AnimationHandleExtensions.Resume(AnimationHandle)"/></description></item>
        /// <item><term>Cancel</term> <description><see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/></description></item>
        /// <item><term>Complete</term> <description><see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/></description></item>
        /// </list>
        /// </returns>
        /// <exception cref="ArgumentException">Throws when <paramref name="durationInSeconds"/> is invalid.</exception>
        public static AnimationHandle Loop<T>(this T animation, float durationInSeconds, int iterations = AnimationHandle.Infinite) where T : struct, IAnimation
        {
            IAnimationExtensions.InternalMethod_2751(durationInSeconds);

            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2949(ref animation, durationInSeconds, iterations));
        }

        internal static void InternalMethod_2751(float InternalParameter_2564)
        {
            if (InternalParameter_2564 < 0 || float.IsInfinity(InternalParameter_2564) || float.IsNaN(InternalParameter_2564))
            {
                throw new ArgumentException($"Provided {nameof(InternalParameter_2564)} must be within range [0, {float.MaxValue}]. Received [{InternalParameter_2564}].", nameof(InternalParameter_2564));
            }
        }
    }
}
