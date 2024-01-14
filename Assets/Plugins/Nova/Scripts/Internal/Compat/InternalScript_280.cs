// Copyright (c) Supernova Technologies LLC

using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Jobs;
using Unity.Jobs.LowLevel.Unsafe;

namespace Nova.Compat
{
    [JobProducerType(typeof(INovaJobExtensions.JobProducer<>))]
    internal interface INovaJob : IJob { }

    [JobProducerType(typeof(INovaJobParallelForExtensions.JobParallelForProducer<>))]
    internal interface INovaJobParallelFor : IJobParallelFor
    { }

    internal static class INovaJobExtensions
    {
        public static unsafe void RunByRef<T>(this ref T jobData) where T : struct, INovaJob
        {
            JobsUtility.JobScheduleParameters InternalVar_1 = JobProducer<T>.RunParams;
            InternalVar_1.JobDataPtr = new IntPtr(UnsafeUtility.AddressOf(ref jobData));

            JobsUtility.Schedule(ref InternalVar_1);
        }

        public static unsafe JobHandle NovaScheduleByRef<T>(this ref T jobData, JobHandle dependsOn = default) where T : struct, INovaJob
        {
            JobsUtility.JobScheduleParameters InternalVar_1 = JobProducer<T>.ScheduleParams;
            InternalVar_1.JobDataPtr = new IntPtr(UnsafeUtility.AddressOf(ref jobData));
            InternalVar_1.Dependency = dependsOn;

            return JobsUtility.Schedule(ref InternalVar_1);
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public unsafe struct JobProducer<T> where T : struct, INovaJob
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly JobsUtility.JobScheduleParameters RunParams = new JobsUtility.JobScheduleParameters(null, ReflectionData, default, ScheduleMode.Run);
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly JobsUtility.JobScheduleParameters ScheduleParams = new JobsUtility.JobScheduleParameters(null, ReflectionData, default, ScheduleMode.Single);

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static IntPtr reflectionData;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static IntPtr ReflectionData
            {
                get
                {
                    if (reflectionData == IntPtr.Zero)
                    {
                        reflectionData = JobsUtility.CreateJobReflectionData(typeof(T), typeof(T), (ExecuteJobFunction)Execute);
                    }

                    return reflectionData;
                }
            }

            private delegate void ExecuteJobFunction(ref T jobData);

            [Obfuscation]
            private static void Execute(ref T jobData)
            {
                jobData.Execute();
            }
        }
    }

    internal static class INovaJobParallelForExtensions
    {
        public static unsafe JobHandle NovaScheduleByRef<T>(this ref T jobData, int arrayLength, int innerloopBatchCount, JobHandle dependsOn = default) where T : struct, INovaJobParallelFor
        {

            JobsUtility.JobScheduleParameters InternalVar_1 = JobParallelForProducer<T>.ParallelScheduleParams;
            InternalVar_1.JobDataPtr = new IntPtr(UnsafeUtility.AddressOf(ref jobData));
            InternalVar_1.Dependency = dependsOn;
            return JobsUtility.ScheduleParallelFor(ref InternalVar_1, arrayLength, innerloopBatchCount);
        }

        public static unsafe JobHandle ScheduleByRef<T>(this ref T jobData, int* arrayLength, int innerloopBatchCount, JobHandle dependsOn = default) where T : struct, INovaJobParallelFor
        {
            JobsUtility.JobScheduleParameters InternalVar_1 = JobParallelForProducer<T>.ParallelScheduleParams;
            InternalVar_1.JobDataPtr = new IntPtr(UnsafeUtility.AddressOf(ref jobData));
            InternalVar_1.Dependency = dependsOn;

            var InternalVar_2 = (byte*)arrayLength - sizeof(void*);
            return JobsUtility.ScheduleParallelForDeferArraySize(ref InternalVar_1, innerloopBatchCount, InternalVar_2, null);
        }

        public static unsafe JobHandle ScheduleByRef<T,U>(this ref T jobData, NativeList<U> list, int innerloopBatchCount, JobHandle dependsOn = default) 
            where T : struct, INovaJobParallelFor
            where U : unmanaged
        {
            JobsUtility.JobScheduleParameters InternalVar_1 = JobParallelForProducer<T>.ParallelScheduleParams;
            InternalVar_1.JobDataPtr = new IntPtr(UnsafeUtility.AddressOf(ref jobData));
            InternalVar_1.Dependency = dependsOn;

            void* InternalVar_2 = null;
#if ENABLE_UNITY_COLLECTIONS_CHECKS
            var InternalVar_3 = NativeListUnsafeUtility.GetAtomicSafetyHandle(ref list);
            InternalVar_2 = UnsafeUtility.AddressOf(ref InternalVar_3);
#endif

            var InternalVar_4 = NativeListUnsafeUtility.GetInternalListDataPtrUnchecked(ref list);
            return JobsUtility.ScheduleParallelForDeferArraySize(ref InternalVar_1, innerloopBatchCount, InternalVar_4, InternalVar_2);
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public unsafe struct JobParallelForProducer<T> where T : struct, INovaJobParallelFor
        {
            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static readonly JobsUtility.JobScheduleParameters ParallelScheduleParams = new JobsUtility.JobScheduleParameters(null, ParallelReflectionData, default, ScheduleMode.Parallel);

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            private static IntPtr parallelReflectionData;

            [System.Diagnostics.DebuggerBrowsable(System.Diagnostics.DebuggerBrowsableState.Never)]
            public static IntPtr ParallelReflectionData
            {
                get
                {
                    if (parallelReflectionData == IntPtr.Zero)
                    {
                        parallelReflectionData = JobsUtility.CreateJobReflectionData(typeof(T), typeof(T), (ExecuteJobParallel)Execute);
                    }

                    return parallelReflectionData;
                }
            }

            private delegate void ExecuteJobParallel(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex);

            [Obfuscation]
            private static unsafe void Execute(ref T jobData, IntPtr additionalPtr, IntPtr bufferRangePatchData, ref JobRanges ranges, int jobIndex)
            {
                while (JobsUtility.GetWorkStealingRange(ref ranges, jobIndex, out int InternalVar_1, out int InternalVar_2))
                {
                    for (var InternalVar_3 = InternalVar_1; InternalVar_3 < InternalVar_2; ++InternalVar_3)
                    {
                        jobData.Execute(InternalVar_3);
                    }
                }
            }

        }
    }
}
