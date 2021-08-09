/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Shake
 *
 * Since  : 2017-8-22
 * Update : 2020-9-8
 * Author : scott.cgi
 */

using UnityEngine;

namespace MojoUnity
{
    public static class TransformExtensions
    {
        public static void SetPositionX(this Transform transform, float x)
        {
            var v3             = transform.position;
            v3.x               = x;
            transform.position = v3;
        }


        public static void SetPositionY(this Transform transform, float y)
        {
            var v3             = transform.position;
            v3.y               = y;
            transform.position = v3;
        }


        public static void SetPositionZ(this Transform transform, float z)
        {
            var v3             = transform.position;
            v3.z               = z;
            transform.position = v3;
        }


        public static void SetPositionXY(this Transform transform, in Vector2 v2)
        {
            transform.position = new Vector3(v2.x, v2.y, transform.position.z);
        }


        public static void SetScaleX(this Transform transform, float x)
        {
            var v3               = transform.localScale;
            v3.x                 = x;
            transform.localScale = v3;
        }


        public static void SetScaleY(this Transform transform, float y)
        {
            var v3               = transform.localScale;
            v3.y                 = y;
            transform.localScale = v3;
        }


        public static void SetScaleZ(this Transform transform, float z)
        {
            var v3               = transform.localScale;
            v3.z                 = z;
            transform.localScale = v3;
        }


        public static void SetScaleXY(this Transform transform, in Vector2 v2)
        {
            transform.localScale = new Vector3(v2.x, v2.y, transform.localScale.z);
        }


        public static void SetRotationX(this Transform transform, float x)
        {
            var v3                = transform.eulerAngles;
            v3.x                  = x;
            transform.eulerAngles = v3;
        }


        public static void SetRotationY(this Transform transform, float y)
        {
            var v3                = transform.eulerAngles;
            v3.y                  = y;
            transform.eulerAngles = v3;
        }


        public static void SetRotationZ(this Transform transform, float z)
        {
            var v3                = transform.eulerAngles;
            v3.z                  = z;
            transform.eulerAngles = v3;
        }
    }
}