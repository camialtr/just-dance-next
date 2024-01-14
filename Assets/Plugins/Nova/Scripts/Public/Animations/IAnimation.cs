// Copyright (c) Supernova Technologies LLC
namespace Nova
{
    /// <summary>
    /// A common interface to implement for simple animation structs which just need a call to <see cref="Update(float)"/>.
    /// </summary>
    /// <seealso cref="IAnimationWithEvents"/>
    /// <seealso cref="IAnimationExtensions"/>
    public interface IAnimation
    {
        /// <summary>
        /// Called once per frame while the animation is running and provides a <paramref name="percentDone"/>, [0, 1] where <c>1 == 100%</c>, for the current animation iteration.
        /// </summary>
        /// <remarks>
        /// <see cref="Update(float)"/> will be called with a value of <c>0</c> at the start and <c>1</c> on complete in all scenarios <i>except</i>:
        /// <list type="bullet">
        /// <item><description>If the animation is <c>0</c> seconds in duration, <c>percentDone == 0</c> <i>will not</i> be provided. <c>percentDone == 1</c> <i>will</i> be provided.</description></item>
        /// <item><description>If <see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/> is called before animation starts, <c>percentDone == 0</c> <i>will not</i> be provided. <c>percentDone == 1</c> <i>will</i> be provided.</description></item>
        /// <item><description>If <see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/> is called before the animation starts, <c>percentDone == 0</c> <i>will not</i> be provided.</description></item>
        /// <item><description>If <see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/> is called before the animation completes, <c>percentDone == 1</c> <i>will not</i> be provided.</description></item>
        /// </list>
        /// </remarks>
        /// <param name="percentDone">The percent, [0, 1] where <c>1 == 100%</c>, of the animation that has already run.</param>
        /// 
        ///
        /// <example>
        /// <code>
        /// using Nova;
        /// using UnityEngine;
        /// 
        /// public struct PositionAnimation : <see cref="IAnimation"/>
        /// {
        ///     public <see cref="UIBlock"/> BlockToAnimate;
        ///     
        ///     public Vector3 StartPosition;
        ///     public Vector3 EndPosition;
        ///     
        ///     public void Update(float percentDone)
        ///     {
        ///         BlockToAnimate.<see cref="UIBlock.Position">Position</see>.<see cref="Length3.Value">Value</see> = Vector3.Lerp(StartPosition, EndPosition, percentDone);
        ///     }
        /// }
        /// 
        /// </code>
        /// </example>
        void Update(float percentDone);
    }

    /// <summary>
    /// A common interface to implement for all animation structs which wish to receive a range of animation events beyond the baseline <c>Update(float percentDone)</c> event.
    /// </summary>
    /// <seealso cref="IAnimation"/>
    /// <seealso cref="IAnimationWithEventsExtensions"/>
    public interface IAnimationWithEvents
    {
        /// <summary>
        /// Called <i>before</i> the first call to <see cref="IAnimationWithEvents.Update"/> for each iteration.
        /// </summary>
        /// <param name="currentIteration">The current iteration that's about to run, beginning at 0.</param>
        void Begin(int currentIteration);

        /// <summary>
        /// Called <i>after</i> the last call to <see cref="IAnimationWithEvents.Update"/> for each iteration.
        /// </summary>
        /// <remarks>Won't be called if the animation is canceled via <see cref="OnCanceled"/></remarks>
        void End();

        /// <summary>
        /// Called once per frame while the animation is running and provides a <paramref name="percentDone"/>, [0, 1] where <c>1 == 100%</c>, for the current animation iteration.
        /// </summary>
        /// <remarks>
        /// <see cref="Update(float)"/> will be called with a value of <c>0</c> at the start and <c>1</c> on complete in all scenarios <i>except</i>:
        /// <list type="bullet">
        /// <item><description>If the animation is <c>0</c> seconds in duration, <c>percentDone == 0</c> <i>will not</i> be provided. <c>percentDone == 1</c> <i>will</i> be provided.</description></item>
        /// <item><description>If <see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/> is called before animation starts, <c>percentDone == 0</c> <i>will not</i> be provided. <c>percentDone == 1</c> <i>will</i> be provided.</description></item>
        /// <item><description>If <see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/> is called before the animation starts, <c>percentDone == 0</c> <i>will not</i> be provided.</description></item>
        /// <item><description>If <see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/> is called before the animation completes, <c>percentDone == 1</c> <i>will not</i> be provided.</description></item>
        /// </list>
        /// </remarks>
        /// <param name="percentDone">The percent, [0, 1] where <c>1 == 100%</c>, of the animation that has already run for the current iteration.</param>
        void Update(float percentDone);

        /// <summary>
        /// Called <i>after</i> <see cref="End"/> of the final iteration, which may be triggered automatically or explicitly via <see cref="AnimationHandleExtensions.Complete(AnimationHandle)"/>.
        /// </summary>
        /// <remarks>Won't be called if the animation is canceled via <see cref="OnCanceled"/>.</remarks>
        void Complete();

        /// <summary>
        /// Called when the <see cref="AnimationHandle"/> tied to this animation is paused via <see cref="AnimationHandleExtensions.Pause(AnimationHandle)"/>.
        /// </summary>
        void OnPaused();

        /// <summary>
        /// Called when the <see cref="AnimationHandle"/> tied to this animation is resumed via <see cref="AnimationHandleExtensions.Resume(AnimationHandle)"/>.
        /// </summary>
        void OnResumed();

        /// <summary>
        /// Called when the <see cref="AnimationHandle"/> tied to this animation is canceled via <see cref="AnimationHandleExtensions.Cancel(AnimationHandle)"/>.
        /// </summary>
        void OnCanceled();
    }
}

