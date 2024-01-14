// Copyright (c) Supernova Technologies LLC
using Nova.InternalNamespace_0.InternalNamespace_1;

namespace Nova
{
    /// <summary>
    /// A set of <see cref="AnimationHandle"/> extension methods for additional scheduling and state management
    /// </summary>
    /// <seealso cref="IAnimationExtensions"/>
    /// <seealso cref="IAnimationWithEventsExtensions"/>
    public static class AnimationHandleExtensions
    {
        
        internal static void InternalMethod_2691(this AnimationHandle InternalParameter_2248)
        {
            InternalType_120.InternalField_406.InternalMethod_574(InternalParameter_2248.InternalField_2977, InternalParameter_461: false);
        }

        /// <summary>
        /// Immediately cancels all the animations in the animation chain tied to this handle. No more update steps will run. 
        /// This is safe to call on invalid handles.
        /// </summary>
        /// <param name="handle">A handle in the animation chain to cancel</param>
        public static void Cancel(this AnimationHandle handle)
        {
            InternalType_120.InternalField_406.InternalMethod_574(handle.InternalField_2977, InternalParameter_461: true);
        }

        /// <summary>
        /// Pauses the animation referenced by this handle in its current state. The animation can be resumed at a future time.
        /// </summary>
        /// <param name="handle">The handle of the animation to pause</param>
        public static void Pause(this AnimationHandle handle)
        {
            InternalType_120.InternalField_406.InternalMethod_572(handle.InternalField_2977);
        }

        /// <summary>
        /// Resumes a paused animation/animation chain
        /// </summary>
        /// <param name="handle">The handle of the animation to resume</param>
        public static void Resume(this AnimationHandle handle)
        {
            InternalType_120.InternalField_406.InternalMethod_573(handle.InternalField_2977);
        }

        /// <summary>
        /// Indicates if an animation has run to completion
        /// </summary>
        /// <param name="handle">The handle of the animation to check for completion</param>
        /// <returns><see langword="true"/> if the animation is no longer in the animation queue, meaning this will also return <see langword="true"/> for an animation handle that not been scheduled</returns>
        public static bool IsComplete(this AnimationHandle handle)
        {
            return InternalType_120.InternalField_406.InternalMethod_565(handle.InternalField_2977);
        }

        /// <summary>
        /// Moves the animation tied to this handle into its last update step. If the 
        /// animation is set to loop, this call to Complete will also move
        /// the animation into its final iteration, even if the loop is technically infinite.
        /// The animation will then run for that final frame.
        /// </summary>
        /// <param name="handle">The handle of the animation to complete</param>
        public static void Complete(this AnimationHandle handle)
        {
            InternalType_120.InternalField_406.InternalMethod_575(handle.InternalField_2977);
        }

        /// <summary>
        /// Runs the provided <paramref name="animation"/> simultaneously with the animation represented by this <paramref name="handle"/>. The new <paramref name="animation"/> will inherit duration and iterations from the already scheduled animation.
        /// </summary>
        /// <typeparam name="T">The type of the new <paramref name="animation"/> struct</typeparam>
        /// <param name="handle">The handle of the animation to combine <paramref name="animation"/> with</param>
        /// <param name="animation">The new animation to combine with the animation tied to <paramref name="handle"/></param>
        /// <returns>An <see cref="AnimationHandle"/> representing this new animation combination</returns>
        /// <seealso cref="IAnimationExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationExtensions.Loop{T}(T, float, int)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Loop{T}(T, float, int)"/>
        public static AnimationHandle Include<T>(this AnimationHandle handle, T animation) where T : struct, IAnimation
        {
            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2702(handle.InternalField_2977, ref animation));
        }

        /// <summary>
        /// Runs the provided <paramref name="animation"/> simultaneously with the animation represented by this <paramref name="handle"/>
        /// </summary>
        /// <typeparam name="T">The type of the new <paramref name="animation"/> struct</typeparam>
        /// <param name="handle">The handle of the animation to combine <paramref name="animation"/> with</param>
        /// <param name="animation">The new animation to combine with the animation tied to <paramref name="handle"/></param>
        /// <param name="durationInSeconds">The duration, in seconds, to run this new <paramref name="animation"/></param>
        /// <param name="iterations">The number of times to run <paramref name="animation"/> before removing it from the animation queue</param>
        /// <returns>An <see cref="AnimationHandle"/> representing this new animation combination</returns>
        /// <seealso cref="IAnimationExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationExtensions.Loop{T}(T, float, int)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Loop{T}(T, float, int)"/>
        public static AnimationHandle Include<T>(this AnimationHandle handle, T animation, float durationInSeconds, int iterations = AnimationHandle.Once) where T : struct, IAnimation
        {
            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2700(handle.InternalField_2977, ref animation, durationInSeconds, iterations));
        }

        /// <summary>
        /// Runs the provided <paramref name="animation"/> after the animation (or animation group) represented by this <paramref name="handle"/> has completed
        /// </summary>
        /// <typeparam name="T">The type of the new <paramref name="animation"/> struct</typeparam>
        /// <param name="handle">The handle of the animation to run after <paramref name="animation"/></param>
        /// <param name="animation">The new animation to run when the previous animation, tied to <paramref name="handle"/>, completes</param>
        /// <param name="durationInSeconds">The duration, in seconds, to run this new <paramref name="animation"/></param>
        /// <param name="iterations">The number of times to run <paramref name="animation"/> before removing it from the animation queue</param>
        /// <returns>An <see cref="AnimationHandle"/> representing this new animation chain</returns>
        /// <seealso cref="IAnimationExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationExtensions.Loop{T}(T, float, int)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Loop{T}(T, float, int)"/>
        public static AnimationHandle Chain<T>(this AnimationHandle handle, T animation, float durationInSeconds, int iterations = AnimationHandle.Once) where T : struct, IAnimation
        {
            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2733(handle.InternalField_2977, ref animation, durationInSeconds, iterations));
        }
    }

    /// <summary>
    /// A set of <see cref="AnimationHandle"/> extension methods for additional scheduling and state management
    /// </summary>
    /// <seealso cref="IAnimationExtensions"/>
    /// <seealso cref="IAnimationWithEventsExtensions"/>
    public static class AnimationHandleWithEventsExtensions
    {
        /// <summary>
        /// Runs the provided <paramref name="animation"/> simultaneously with the animation represented by this <paramref name="handle"/>. The new <paramref name="animation"/> will inherit duration and iterations from the already scheduled animation.
        /// </summary>
        /// <typeparam name="T">The type of the new <paramref name="animation"/> struct</typeparam>
        /// <param name="handle">The handle of the animation to combine <paramref name="animation"/> with</param>
        /// <param name="animation">The new animation to combine with the animation tied to <paramref name="handle"/></param>
        /// <returns>An <see cref="AnimationHandle"/> representing this new animation combination</returns>
        /// <seealso cref="IAnimationExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationExtensions.Loop{T}(T, float, int)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Loop{T}(T, float, int)"/>
        public static AnimationHandle Include<T>(this AnimationHandle handle, T animation) where T : struct, IAnimationWithEvents
        {
            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2728(handle.InternalField_2977, ref animation));
        }

        /// <summary>
        /// Runs the provided <paramref name="animation"/> simultaneously with the animation represented by this <paramref name="handle"/>
        /// </summary>
        /// <typeparam name="T">The type of the new <paramref name="animation"/> struct</typeparam>
        /// <param name="handle">The handle of the animation to combine <paramref name="animation"/> with</param>
        /// <param name="animation">The new animation to combine with the animation tied to <paramref name="handle"/></param>
        /// <param name="durationInSeconds">The duration, in seconds, to run this new <paramref name="animation"/></param>
        /// <param name="iterations">The number of times to run <paramref name="animation"/> before removing it from the animation queue</param>
        /// <returns>An <see cref="AnimationHandle"/> representing this new animation combination</returns>
        /// <seealso cref="IAnimationExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationExtensions.Loop{T}(T, float, int)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Loop{T}(T, float, int)"/>
        public static AnimationHandle Include<U>(this AnimationHandle handle, U animation, float durationInSeconds, int iterations = AnimationHandle.Once) where U : struct, IAnimationWithEvents
        {
            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2701(handle.InternalField_2977, ref animation, durationInSeconds, iterations));
        }

        /// <summary>
        /// Runs the provided <paramref name="animation"/> after the animation (or animation group) represented by this <paramref name="handle"/> has completed
        /// </summary>
        /// <typeparam name="T">The type of the new <paramref name="animation"/> struct</typeparam>
        /// <param name="handle">The handle of the animation to run after</param>
        /// <param name="animation">The new animation to run when the previous animation, tied to <paramref name="handle"/>, completes</param>
        /// <param name="durationInSeconds">The duration, in seconds, to run this new <paramref name="animation"/></param>
        /// <param name="iterations">The number of times to run <paramref name="animation"/> before removing it from the animation queue</param>
        /// <returns>An <see cref="AnimationHandle"/> representing this new animation chain</returns>
        /// <seealso cref="IAnimationExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationExtensions.Loop{T}(T, float, int)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Run{T}(T, float)"/>
        /// <seealso cref="IAnimationWithEventsExtensions.Loop{T}(T, float, int)"/>
        public static AnimationHandle Chain<T>(this AnimationHandle handle, T animation, float durationInSeconds, int iterations = AnimationHandle.Once) where T : struct, IAnimationWithEvents
        {
            return AnimationHandle.InternalMethod_2692(InternalType_725.InternalMethod_2734(handle.InternalField_2977, ref animation, durationInSeconds, iterations));
        }
    }
}
