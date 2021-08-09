/*
 * Copyright (c) scott.cgi All Rights Reserved.
 * 
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Shake 
 *
 * Since  : 2017-12-2
 * Update : 2020-2-14
 * Author : scott.cgi
 */

using System;
using UnityEngine;

namespace MojoUnity
{
    public static class ShakeExtensions
    {
        /// <summary>
        /// Shake the transform position x.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakePositionX
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration,
                ()  => transform.position.x,
                (x) => transform.SetPositionX(x), 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform position y.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakePositionY
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.position.y,
                (y) => transform.SetPositionY(y), 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform position z.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakePositionZ
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.position.z,
                (z) => transform.SetPositionZ(z), 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform position x y.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakePositionXY
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()   => (Vector2) transform.position,
                (v2) => transform.SetPositionXY(v2),
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform position.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakePosition
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()   => transform.position,
                (v3) => transform.position = v3, 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform scale x.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeScaleX
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.localScale.x,
                (x) => transform.SetScaleX(x),
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform scale y.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeScaleY
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.localScale.y,
                (y) => transform.SetScaleY(y),
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform scale z.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeScaleZ
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.localScale.z,
                (z) => transform.SetScaleZ(z),
                OnComplete
            );            
        }


        /// <summary>
        /// Shake the transform scale x y.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeScaleXY
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()   => (Vector2) transform.localScale,
                (v2) => transform.SetScaleXY(v2), 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform scale.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeScale
        (
            this Transform      transform, 
            float               magnitude  = 0.1f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()   => transform.localScale,
                (v3) => transform.localScale = v3, 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform rotation x.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeRotationX
        (
            this Transform      transform, 
            float               magnitude  = 30.0f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.eulerAngles.x,
                (x) => transform.SetRotationX(x), 
                OnComplete
            );
        }


        /// <summary>
        /// Shake the transform rotation y.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeRotationY
        (
            this Transform      transform, 
            float               magnitude  = 30.0f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.eulerAngles.y,
                (y) => transform.SetRotationY(y), 
                OnComplete
            );            
        }


        /// <summary>
        /// Shake the transform rotation z.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeRotationZ
        (
            this Transform      transform, 
            float               magnitude  = 30.0f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude, 
                speed, 
                duration, 
                ()  => transform.eulerAngles.z,
                (z) => transform.SetRotationZ(z), 
                OnComplete
            ); 
        }


        /// <summary>
        /// Shake the transform rotation.
        /// [magnitude]: shake distance.
        /// </summary>
        public static void ShakeRotation
        (
            this Transform      transform, 
            float               magnitude  = 30.0f, 
            float               speed      = 100.0f, 
            float               duration   = 1.0f, 
            Action              OnComplete = null
        )
        {
            ShakeTool.Shake
            (
                magnitude,
                speed,
                duration,
                ()   => transform.eulerAngles,
                (v3) => transform.eulerAngles = v3,
                OnComplete
            ); ; 
        }
    }
}

