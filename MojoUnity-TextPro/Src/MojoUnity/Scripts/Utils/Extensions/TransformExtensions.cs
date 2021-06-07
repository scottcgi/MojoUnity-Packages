/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: Shared by multiple packages
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


        public static void SetPositionXY(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }


        public static void SetPositionXY(this Transform transform, in Vector2 v2)
        {
            transform.position = new Vector3(v2.x, v2.y, transform.position.z);
        }


        public static void SetPositionXY(this Transform transform, float value)
        {
            transform.position = new Vector3(value, value, transform.position.z);
        }


        public static void SetPositionXY(this Transform transform, Transform transform2)
        {
            var v3             = transform2.position;
            v3.z               = transform.position.z;
            transform.position = v3;
        }


        public static void SetPosition(this Transform transform, float value)
        {
            transform.position = new Vector3(value, value, value);
        }


        public static void SetRelativePositionX(this Transform transform, float x)
        {
            var v3             = transform.position;
            v3.x              += x;
            transform.position = v3;
        }


        public static void SetRelativePositionY(this Transform transform, float y)
        {
            var v3             = transform.position;
            v3.y              += y;
            transform.position = v3;
        }


        public static void SetRelativePositionZ(this Transform transform, float z)
        {
            var v3             = transform.position;
            v3.z              += z;
            transform.position = v3;
        }


        public static void SetRelativePositionXY(this Transform transform, float x, float y)
        {
            var v3              = transform.position;
            v3.x               += x;
            v3.y               += y;
            transform.position  = v3;
        }


        public static void SetRelativePositionXY(this Transform transform, in Vector2 v2)
        {
            var v3              = transform.position;
            v3.x               += v2.x;
            v3.y               += v2.y;
            transform.position  = v3;
        }


        public static void SetRelativePositionXY(this Transform transform, float value)
        {
            var v3              = transform.position;
            v3.x               += value;
            v3.y               += value;
            transform.position  = v3;
        }


        public static void SetRelativePositionXY(this Transform transform, Transform transform2)
        {
            var v3             = transform .position;
            var v23            = transform2.position;
            v3.x              += v23.x;
            v3.y              += v23.y;
            transform.position = v3;
        }


        public static void SetRelativePosition(this Transform transform, float value)
        {
            transform.position += new Vector3(value, value, value);
        }


        public static void SetLocalPositionX(this Transform transform, float x)
        {
            var v3                  = transform.localPosition;
            v3.x                    = x;
            transform.localPosition = v3;
        }


        public static void SetLocalPositionY(this Transform transform, float y)
        {
            var v3                  = transform.localPosition;
            v3.y                    = y;
            transform.localPosition = v3;
        }


        public static void SetLocalPositionZ(this Transform transform, float z)
        {
            var v3                  = transform.localPosition;
            v3.z                    = z;
            transform.localPosition = v3;
        }


        public static void SetLocalPositionXY(this Transform transform, float x, float y)
        {
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }


        public static void SetLocalPositionXY(this Transform transform, in Vector2 v2)
        {
            transform.localPosition = new Vector3(v2.x, v2.y, transform.localPosition.z);
        }


        public static void SetLocalPositionXY(this Transform transform, float value)
        {
            transform.localPosition = new Vector3(value, value, transform.localPosition.z);
        }


        public static void SetLocalPositionXY(this Transform transform, Transform transform2)
        {
            var v3                  = transform2.localPosition;
            v3.z                    = transform. localPosition.z;
            transform.localPosition = v3;
        }


        public static void SetLocalPosition(this Transform transform, float value)
        {
            transform.localPosition = new Vector3(value, value, value);
        }


        public static void SetRelativeLocalPositionX(this Transform transform, float x)
        {
            var v3                  = transform.localPosition;
            v3.x                   += x;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPositionY(this Transform transform, float y)
        {
            var v3                  = transform.localPosition;
            v3.y                   += y;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPositionZ(this Transform transform, float z)
        {
            var v3                  = transform.localPosition;
            v3.z                   += z;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPositionXY(this Transform transform, float x, float y)
        {
            var v3                  = transform.localPosition;
            v3.x                   += x;
            v3.y                   += y;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPositionXY(this Transform transform, in Vector2 v2)
        {
            var v3                  = transform.localPosition;
            v3.x                   += v2.x;
            v3.y                   += v2.y;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPositionXY(this Transform transform, float value)
        {
            var v3                  = transform.localPosition;
            v3.x                   += value;
            v3.y                   += value;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPositionXY(this Transform transform, Transform transform2)
        {
            var v3                  = transform. localPosition;
            var v23                 = transform2.localPosition;
            v3.x                   += v23.x;
            v3.y                   += v23.y;
            transform.localPosition = v3;
        }


        public static void SetRelativeLocalPosition(this Transform transform, float value)
        {
            transform.localPosition += new Vector3(value, value, value);
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


        public static void SetScaleXY(this Transform transform, float x, float y)
        {
            transform.localScale = new Vector3(x, y, transform.localScale.z);
        }


        public static void SetScaleXY(this Transform transform, in Vector2 v2)
        {
            transform.localScale = new Vector3(v2.x, v2.y, transform.localScale.z);
        }


        public static void SetScaleXY(this Transform transform, float value)
        {
            transform.localScale = new Vector3(value, value, transform.localScale.z);
        }


        public static void SetScaleXY(this Transform transform, Transform transform2)
        {
            var v3               = transform2.localScale;
            v3.z                 = transform. localScale.z;
            transform.localScale = v3;
        }


        public static void SetScale(this Transform transform, float value)
        {
            transform.localScale = new Vector3(value, value, value);
        }


        public static void SetRelativeScaleX(this Transform transform, float x)
        {
            var v3               = transform.localScale;
            v3.x                += x;
            transform.localScale = v3;
        }


        public static void SetRelativeScaleY(this Transform transform, float y)
        {
            var v3               = transform.localScale;
            v3.y                += y;
            transform.localScale = v3;
        }


        public static void SetRelativeScaleZ(this Transform transform, float z)
        {
            var v3               = transform.localScale;
            v3.z                += z;
            transform.localScale = v3;
        }


        public static void SetRelativeScaleXY(this Transform transform, float x, float y)
        {
            var v3               = transform.localScale;
            v3.x                += x;
            v3.y                += y;
            transform.localScale = v3;
        }


        public static void SetRelativeScaleXY(this Transform transform, in Vector2 v2)
        {
            var v3               = transform.localScale;
            v3.x                += v2.x;
            v3.y                += v2.y;
            transform.localScale = v3;
        }


        public static void SetRelativeScaleXY(this Transform transform, float value)
        {
            var v3               = transform.localScale;
            v3.x                += value;
            v3.y                += value;
            transform.localScale = v3;
        }


        public static void SetRelativeScaleXY(this Transform transform, Transform transform2)
        {
            var v3               = transform. localScale;
            var v23              = transform2.localScale;
            v3.x                += v23.x;
            v3.y                += v23.y;
            transform.localScale = v3;
        }


        public static void SetRelativeScale(this Transform transform, float value)
        {
            transform.localScale += new Vector3(value, value, value);
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


        public static void SetRelativeRotationX(this Transform transform, float x)
        {
            var v3                = transform.eulerAngles;
            v3.x                 += x;
            transform.eulerAngles = v3;
        }


        public static void SetRelativeRotationY(this Transform transform, float y)
        {
            var v3                = transform.eulerAngles;
            v3.y                 += y;
            transform.eulerAngles = v3;
        }


        public static void SetRelativeRotationZ(this Transform transform, float z)
        {
            var v3                = transform.eulerAngles;
            v3.z                 += z;
            transform.eulerAngles = v3;
        }


        public static void SetLocalRotationX(this Transform transform, float x)
        {
            var v3                     = transform.localEulerAngles;
            v3.x                       = x;
            transform.localEulerAngles = v3;
        }


        public static void SetLocalRotationY(this Transform transform, float y)
        {
            var v3                     = transform.localEulerAngles;
            v3.y                       = y;
            transform.localEulerAngles = v3;
        }


        public static void SetLocalRotationZ(this Transform transform, float z)
        {
            var v3                     = transform.localEulerAngles;
            v3.z                       = z;
            transform.localEulerAngles = v3;
        }


        public static void SetRelativeLocalRotationX(this Transform transform, float x)
        {
            var v3                     = transform.localEulerAngles;
            v3.x                      += x;
            transform.localEulerAngles = v3;
        }


        public static void SetRelativeLocalRotationY(this Transform transform, float y)
        {
            var v3                     = transform.localEulerAngles;
            v3.y                      += y;
            transform.localEulerAngles = v3;
        }


        public static void SetRelativeLocalRotationZ(this Transform transform, float z)
        {
            var v3                     = transform.localEulerAngles;
            v3.z                      += z;
            transform.localEulerAngles = v3;
        }


        public static void SetAnchoredPositionX(this RectTransform rectTransform, float x)
        {
            var v2                         = rectTransform.anchoredPosition;
            v2.x                           = x;
            rectTransform.anchoredPosition = v2;
        }


        public static void SetAnchoredPositionY(this RectTransform rectTransform, float y)
        {
            var v2                         = rectTransform.anchoredPosition;
            v2.y                           = y;
            rectTransform.anchoredPosition = v2;
        }


        public static void SetAnchoredPositionZ(this RectTransform rectTransform, float z)
        {
            var v3                           = rectTransform.anchoredPosition3D;
            v3.z                             = z;
            rectTransform.anchoredPosition3D = v3;
        }


        public static void SetAnchoredPositionXY(this RectTransform rectTransform, float x, float y)
        {
            rectTransform.anchoredPosition = new Vector2(x, y);
        }


        public static void SetAnchoredPositionXY(this RectTransform rectTransform, float value)
        {
            rectTransform.anchoredPosition = new Vector2(value, value);
        }


        public static void SetAnchoredPosition3D(this RectTransform rectTransform, float value)
        {
            rectTransform.anchoredPosition3D = new Vector3(value, value, value);
        }


        public static void SetRelativeAnchoredPositionX(this RectTransform rectTransform, float x)
        {
            var v2                         = rectTransform.anchoredPosition;
            v2.x                          += x;
            rectTransform.anchoredPosition = v2;
        }


        public static void SetRelativeAnchoredPositionY(this RectTransform rectTransform, float y)
        {
            var v2                         = rectTransform.anchoredPosition;
            v2.y                          += y;
            rectTransform.anchoredPosition = v2;
        }


        public static void SetRelativeAnchoredPositionZ(this RectTransform rectTransform, float z)
        {
            var v3                           = rectTransform.anchoredPosition3D;
            v3.z                            += z;
            rectTransform.anchoredPosition3D = v3;
        }


        public static void SetRelativeAnchoredPositionXY(this RectTransform rectTransform, float x, float y)
        {
            var v2                         = rectTransform.anchoredPosition;
            v2.x                          += x;
            v2.y                          += y;
            rectTransform.anchoredPosition = v2;
        }


        public static void SetRelativeAnchoredPositionXY(this RectTransform rectTransform, in Vector2 v2)
        {
            var pos                        = rectTransform.anchoredPosition;
            pos.x                         += v2.x;
            pos.y                         += v2.y;
            rectTransform.anchoredPosition = pos;
        }


        public static void SetRelativeAnchoredPositionXY(this RectTransform rectTransform, float value)
        {
            var v2                         = rectTransform.anchoredPosition;
            v2.x                          += value;
            v2.y                          += value;
            rectTransform.anchoredPosition = v2;
        }


        public static void SetRelativeAnchoredPositionXY(this RectTransform rectTransform, RectTransform rectTransform2)
        {
            var pos                        = rectTransform .anchoredPosition;
            var v2                         = rectTransform2.anchoredPosition;
            pos.x                         += v2.x;
            pos.y                         += v2.y;
            rectTransform.anchoredPosition = pos;
        }


        public static void SetRelativeAnchoredPosition3D(this RectTransform rectTransform, float value)
        {
            rectTransform.anchoredPosition3D += new Vector3(value, value, value);
        }


        public static void SetOffsetMaxX(this RectTransform rectTransform, float x)
        {                           
            var offsetMax           = rectTransform.offsetMax;
            offsetMax.x             = x;
            rectTransform.offsetMax = offsetMax;
        }


        public static void SetRelativeOffsetMaxX(this RectTransform rectTransform, float x)
        {                           
            var offsetMax           = rectTransform.offsetMax;
            offsetMax.x            += x;
            rectTransform.offsetMax = offsetMax;
        }


        public static void SetOffsetMaxY(this RectTransform rectTransform, float y)
        {                           
            var offsetMax           = rectTransform.offsetMax;
            offsetMax.y             = y;
            rectTransform.offsetMax = offsetMax;
        }


        public static void SetRelativeOffsetMaxY(this RectTransform rectTransform, float y)
        {                           
            var offsetMax           = rectTransform.offsetMax;
            offsetMax.y            += y;
            rectTransform.offsetMax = offsetMax;
        }


        public static void SetRelativeOffsetMax(this RectTransform rectTransform, float x, float y)
        {                           
            rectTransform.offsetMax += new Vector2(x, y);
        }


        public static void SetOffsetMinX(this RectTransform rectTransform, float x)
        {                           
            var offsetMin           = rectTransform.offsetMin;
            offsetMin.x             = x;
            rectTransform.offsetMin = offsetMin;
        }


        public static void SetRelativeOffsetMinX(this RectTransform rectTransform, float x)
        {                           
            var offsetMin           = rectTransform.offsetMin;
            offsetMin.x            += x;
            rectTransform.offsetMin = offsetMin;
        }


        public static void SetOffsetMinY(this RectTransform rectTransform, float y)
        {                           
            var offsetMin           = rectTransform.offsetMin;
            offsetMin.y             = y;
            rectTransform.offsetMin = offsetMin;
        }


        public static void SetSetRelativeOffsetMinY(this RectTransform rectTransform, float y)
        {                           
            var offsetMin           = rectTransform.offsetMin;
            offsetMin.y            += y;
            rectTransform.offsetMin = offsetMin;
        }


        public static void SetSetRelativeOffsetMin(this RectTransform rectTransform, float x, float y)
        {                           
            rectTransform.offsetMin += new Vector2(x, y);
        }
    }
}