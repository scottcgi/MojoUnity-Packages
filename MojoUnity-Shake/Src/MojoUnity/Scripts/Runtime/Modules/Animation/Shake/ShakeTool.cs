/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Shake 
 *
 * Since  : 2017-12-1
 * Update : 2021-8-7
 * Author : scott.cgi
 */

using System.Collections;
using UnityEngine;
using System;
using Unity.Burst;
using Unity.Mathematics;

namespace MojoUnity
{
    [BurstCompile]
    public static class ShakeTool 
    {
        private const float RandomRange = 1234.5f;


        /// <summary>
        /// Shake float.
        /// [magnitude]: shake distance.
        /// [OnShake]  : call every frame for get shaked float.
        /// </summary>
        public static void Shake
        (
            float         magnitude, 
            float         speed, 
            float         duration, 
            Func<float>   OnGetOriginal,
            Action<float> OnShake, 
            Action        OnComplete
        )
        {
            CoroutineExecutor.StartTask
            (
                ShakeRoutine(magnitude, speed, duration, OnGetOriginal, OnShake, OnComplete)
            );
        }


        /// <summary>
        /// Shake Vector2.
        /// [magnitude]: shake distance.
        /// [OnShake]  : call every frame for get shaked Vector2.
        /// </summary>
        public static void Shake
        (
            float           magnitude, 
            float           speed, 
            float           duration, 
            Func<Vector2>   OnGetOriginal,
            Action<Vector2> OnShake, 
            Action          OnComplete
        )
        {
            CoroutineExecutor.StartTask
            (
                ShakeRoutine(magnitude, speed, duration, OnGetOriginal,OnShake, OnComplete)
            );
        }


        /// <summary>
        /// Shake Vector3.
        /// [magnitude]: shake distance.
        /// [OnShake]  : call every frame for get shaked Vector3.
        /// </summary>
        public static void Shake
        (
            float           magnitude, 
            float           speed, 
            float           duration, 
            Func<Vector3>   OnGetOriginal,
            Action<Vector3> OnShake,
            Action          OnComplete
        )
        {
            CoroutineExecutor.StartTask
            (
                ShakeRoutine(magnitude, speed, duration, OnGetOriginal, OnShake, OnComplete)
            );
        }


        /// <summary>
        /// The shake float routine.
        /// [magnitude]: shake distance.
        /// [OnShake]  : call every frame for get shaked float.
        /// </summary>
        public static IEnumerator ShakeRoutine
        (
            float           magnitude, 
            float           speed,
            float           duration,
            Func<float>     OnGetOriginal,
            Action<float>   OnShake, 
            Action          OnComplete
        )
        {
            var original = OnGetOriginal();
            var data     = new ShakeDataRandom1()
            {
                magnitude = magnitude,
                speed     = speed,
                duration  = duration,
                elapsed   = 0.0f,
                random    = UnityEngine.Random.Range(-RandomRange, RandomRange),
            };

            while (data.elapsed < duration) 
            {
                data.deltaTime = Time.deltaTime;          
                OnShake(ShakeFloat(ref data, original));
                yield return null;
            }

            OnShake(original);
            OnComplete?.Invoke();
        }


        /// <summary>
        /// Shake float by params.
        /// </summary>
        [BurstCompile]
        private static float ShakeFloat(ref ShakeDataRandom1 data, float original)
        {
            data.elapsed += data.deltaTime;
            var percent   = data.elapsed / data.duration;   
            var rps       = data.random  + percent * data.speed;
            var range     = Mathf.PerlinNoise(rps, rps);

            // map to [-1, 1]
            range = math.mad(range, 2.0f, -1.0f);

            if (percent < 0.5f)
            {
                return math.mad(range, data.magnitude, original);
                // range * data.magnitude + original;
            }
            else 
            {
                // speed decay
                return math.mad(math.mul(range, data.magnitude), math.mul(2.0f, 1.0f - percent), original);
                // range * data.magnitude * (2.0f * (1.0f - percent)) + original;
            }
        }


        /// <summary>
        /// The shake Vector2 routine.
        /// [magnitude]: shake distance.
        /// [OnShake]  : call every frame for get shaked Vector2.
        /// </summary>
        public static IEnumerator ShakeRoutine
        (
            float           magnitude, 
            float           speed,
            float           duration, 
            Func<Vector2>   OnGetOriginal,
            Action<Vector2> OnShake, 
            Action          OnComplete
        )
        {
            var original  = (float2) OnGetOriginal();
            var result    = float2.zero;
            var data      = new ShakeDataRandom2()
            {
                magnitude = magnitude,
                speed     = speed,
                duration  = duration,
                elapsed   = 0.0f,
                random1   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                random2   = UnityEngine.Random.Range(-RandomRange, RandomRange),
            };

            while (data.elapsed < duration) 
            {
                data.deltaTime = Time.deltaTime;
                ShakeVector2(ref data, ref original, ref result);
                OnShake(result);
                yield return null;
            }

            OnShake(original);
            OnComplete?.Invoke();
        }


        /// <summary>
        /// Shake Vector2 by params.
        /// </summary>
        [BurstCompile]
        private static void ShakeVector2(ref ShakeDataRandom2 data, ref float2 original, ref float2 result)
        {
            data.elapsed += data.deltaTime;
            var percent   = data.elapsed / data.duration;   
            var ps        = percent      * data.speed;
            var range1    = Mathf.PerlinNoise(data.random1 + ps, 0.0f);
            var range2    = Mathf.PerlinNoise(0.0f, data.random2 + ps);

            // map to [-1, 1]
            var range = new float2(math.mad(range1, 2.0f, -1.0f), math.mad(range2, 2.0f, -1.0f));

            if (percent < 0.5f)
            {
                result = range * data.magnitude + original;
            }
            else
            {
                // speed decay
                var decay = math.mul(data.magnitude, math.mul(2.0f, 1.0f - percent));
                // data.magnitude * (2.0f * (1.0f - percent));
                result    = range * decay + original;
            }
        }


        /// <summary>
        /// The shake Vector3 routine.
        /// [magnitude]: shake distance.
        /// [OnShake]: call every frame for get shaked Vector3.
        /// </summary>
        public static IEnumerator ShakeRoutine
        (
            float           magnitude, 
            float           speed,
            float           duration, 
            Func<Vector3>   OnGetOriginal,
            Action<Vector3> OnShake, 
            Action          OnComplete
        )
        {
            var original  = (float3) OnGetOriginal();
            var result    = float3.zero;
            var data      = new ShakeDataRandom3()
            {
                magnitude = magnitude,
                speed     = speed,
                duration  = duration,
                elapsed   = 0.0f,
                random1   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                random2   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                random3   = UnityEngine.Random.Range(-RandomRange, RandomRange),
            };

            while (data.elapsed < duration) 
            {
                data.deltaTime = Time.deltaTime;
                ShakeVector3(ref data, ref original, ref result);
                OnShake(result);
                yield return null;
            }

            OnShake(original);
            OnComplete?.Invoke();
        }


        /// <summary>
        /// Shake Vector3 by params.
        /// </summary>
        [BurstCompile]
        private static void ShakeVector3(ref ShakeDataRandom3 data, ref float3 original, ref float3 result)
        {
            data.elapsed += data.deltaTime;
            var percent   = data.elapsed / data.duration;
            var ps        = percent * data.speed;
            var range1    = Mathf.PerlinNoise(data.random1 + ps, 0.0f);
            var range2    = Mathf.PerlinNoise(0.0f,              data.random2 + ps);
            var range3    = Mathf.PerlinNoise(data.random3 + ps, data.random3 + ps);

            // map to [-1, 1]
            var range = new float3
            (
                math.mad(range1, 2.0f, -1.0f),
                math.mad(range2, 2.0f, -1.0f),
                math.mad(range3, 2.0f, -1.0f)
            );

            if (percent < 0.5f)
            {
                result = range * data.magnitude + original;
            }
            else
            {
                // speed decay
                var decay = math.mul(data.magnitude, math.mul(2.0f, 1.0f - percent));
                // data.magnitude * (2.0f * (1.0f - percent));
                result    = range * decay + original;
            }
        }


        private struct ShakeDataRandom1
        {
            public float magnitude;
            public float speed;
            public float duration;
            public float elapsed;
            public float deltaTime;
            public float random;
        }


        private struct ShakeDataRandom2
        {
            public float magnitude;
            public float speed;
            public float duration;
            public float elapsed;
            public float deltaTime;
            public float random1;
            public float random2;
        }


        private struct ShakeDataRandom3
        {
            public float magnitude;
            public float speed;
            public float duration;
            public float elapsed;
            public float deltaTime;
            public float random1;
            public float random2;
            public float random3;
        }
    }
}


