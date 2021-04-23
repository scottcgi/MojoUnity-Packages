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
 * Update : 2020-2-14
 * Author : scott.cgi
 */

using System.Collections;
using UnityEngine;
using System;
using Unity.Burst;
using Unity.Mathematics;

namespace MojoUnity
{
    #if ENABLE_BURST_AOT
    [BurstCompile]
    #endif
    public static class ShakeTool 
    {
        public enum ShakeType
        {
            Smooth,
            PerlinNoise,
        }


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
            Action        OnComplete,
            ShakeType     shakeType
        )
        {
            CoroutineExecutor.StartTask
            (
                ShakeRoutine(magnitude, speed, duration, OnGetOriginal, OnShake, OnComplete, shakeType)
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
            Action          OnComplete,
            ShakeType       shakeType
        )
        {
            CoroutineExecutor.StartTask
            (
                ShakeRoutine(magnitude, speed, duration, OnGetOriginal,OnShake, OnComplete, shakeType)
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
            Action          OnComplete,
            ShakeType       shakeTpe
        )
        {
            CoroutineExecutor.StartTask
            (
                ShakeRoutine(magnitude, speed, duration, OnGetOriginal, OnShake, OnComplete, shakeTpe)
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
            Action          OnComplete,
            ShakeType       shakeType
        )
        {
            var original = OnGetOriginal();
            var data     = new ShakeData1()
            {
                magnitude = magnitude,
                speed     = speed,
                duration  = duration,
                elapsed   = 0.0f,
                random    = UnityEngine.Random.Range(-RandomRange, RandomRange),
                shakeType = shakeType
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
        #if ENABLE_BURST_AOT
        [BurstCompile]
        #endif        
        private static float ShakeFloat(ref ShakeData1 data, float original)
        {
            data.elapsed += data.deltaTime;
            var percent   = data.elapsed / data.duration;   
            var rps       = data.random  + percent * data.speed;

            // map to [-1, 1]
            var range = 0.0f;

            switch (data.shakeType)
            {
                case ShakeType.Smooth:
                    range = math.sin(rps) + math.cos(rps);
                    break;

                case ShakeType.PerlinNoise:
                    range = Mathf.PerlinNoise(rps, rps);
                    break;
            }

            // reduce shake start from 50% duration
            if (percent < 0.5f)
            {
                return range * data.magnitude + original;
            }
            else 
            {
                return range * data.magnitude * (2.0f * (1.0f - percent)) + original;
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
            Action          OnComplete,
            ShakeType       shakeType
        )
        {
            var     original = OnGetOriginal();
            Vector2 result   = Vector2.zero;
            var     data     = new ShakeData2()
            {
                magnitude = magnitude,
                speed     = speed,
                duration  = duration,
                elapsed   = 0.0f,
                random1   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                random2   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                shakeType = shakeType
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
        #if ENABLE_BURST_AOT
        [BurstCompile]
        #endif        
        private static void ShakeVector2(ref ShakeData2 data, ref Vector2 original, ref Vector2 result)
        {
            data.elapsed += data.deltaTime;
            var percent   = data.elapsed / data.duration;   
            var ps        = percent      * data.speed;

            // map to [-1, 1]
            var range1 = 0.0f;
            var range2 = 0.0f;

            switch (data.shakeType)
            {
                case ShakeType.Smooth:
                    range1 = math.sin(data.random1 + ps);
                    range2 = math.cos(data.random2 + ps);
                    break;

                case ShakeType.PerlinNoise:
                    range1 = Mathf.PerlinNoise(data.random1 + ps, 0.0f);
                    range2 = Mathf.PerlinNoise(0.0f, data.random2 + ps);
                    break;
            }

            // reduce shake start from 50% duration
            if (percent < 0.5f)
            {
                result = new Vector2(range1 * data.magnitude, range2 * data.magnitude) + original;
            }
            else
            {
                var magDecay = data.magnitude * (2.0f * (1.0f - percent));
                result       = new Vector2(range1 * magDecay, range2 * magDecay) + original;
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
            Action          OnComplete,
            ShakeType       shakeType
        )
        {
            var     original = OnGetOriginal();
            Vector3 result   = Vector3.zero;
            var     data     = new ShakeData3()
            {
                magnitude = magnitude,
                speed     = speed,
                duration  = duration,
                elapsed   = 0.0f,
                random1   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                random2   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                random3   = UnityEngine.Random.Range(-RandomRange, RandomRange),
                shakeType = shakeType
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
        #if ENABLE_BURST_AOT
        [BurstCompile]
        #endif        
        private static void ShakeVector3(ref ShakeData3 data, ref Vector3 original, ref Vector3 result)
        {
            data.elapsed += data.deltaTime;
            var percent   = data.elapsed / data.duration;
            var ps        = percent * data.speed;

            // map to [-1, 1]
            var range1   = 0.0f;
            var range2   = 0.0f;
            var range3   = 0.0f;

            switch (data.shakeType)
            {
                case ShakeType.Smooth:
                    range1 = math.sin(data.random1 + ps);
                    range2 = math.cos(data.random2 + ps);
                    range3 = math.sin(data.random3 + ps);
                    break;

                case ShakeType.PerlinNoise:
                    range1 = Mathf.PerlinNoise(data.random1 + ps, 0.0f);
                    range2 = Mathf.PerlinNoise(0.0f,              data.random2 + ps);
                    range3 = Mathf.PerlinNoise(data.random3 + ps, data.random3 + ps);
                    break;
            }

            // reduce shake start from 50% duration
            if (percent < 0.5f)
            {
                result = new Vector3(range1 * data.magnitude, range2 * data.magnitude, range3 * data.magnitude) + original;
            }
            else
            {
                var magDecay = data.magnitude * (2.0f * (1.0f - percent));
                result       = new Vector3(range1 * magDecay, range2 * magDecay, range3 * magDecay) + original;
            }
        }


        #if ENABLE_BURST_AOT
        [BurstCompile]
        #endif    
        private struct ShakeData1
        {
            public float     magnitude;
            public float     speed;
            public float     duration;
            public float     elapsed;
            public float     random;
            public ShakeType shakeType;
            public float     deltaTime;
        }


        #if ENABLE_BURST_AOT
        [BurstCompile]
        #endif    
        private struct ShakeData2
        {
            public float     magnitude;
            public float     speed;
            public float     duration;
            public float     elapsed;
            public float     random1;
            public float     random2;
            public ShakeType shakeType;
            public float     deltaTime;
        }


        #if ENABLE_BURST_AOT
        [BurstCompile]
        #endif    
        private struct ShakeData3
        {
            public float     magnitude;
            public float     speed;
            public float     duration;
            public float     elapsed;
            public float     random1;
            public float     random2;
            public float     random3;
            public ShakeType shakeType;
            public float     deltaTime;
        }
    }
}


