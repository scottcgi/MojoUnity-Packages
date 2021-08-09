/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Shake
 *
 * Since  : 2021-4-20
 * Update : 2021-4-20
 * Author : scott.cgi
 */

using UnityEngine;
using MojoUnity;

public class ShakeTest : MonoBehaviour
{
    public float               speed     = 100f;
    public float               duration  = 2.0f;

    [Space(10)]
    public float               positionMagnitude = 0.2f;
    public bool                isShakePositionX;
    public bool                isShakePositionY;
    public bool                isShakePositionZ;
    public bool                isShakePositionXY;
    public bool                isShakePosition;

    [Space(10)]
    public float               scaleMagnitude    = 0.1f;
    public bool                isShakeScaleX;
    public bool                isShakeScaleY;
    public bool                isShakeScaleZ;
    public bool                isShakeScaleXY;
    public bool                isShakeScale;

    [Space(10)]
    public float               rotationMagnitude = 30.0f;
    public bool                isShakeRotationX;
    public bool                isShakeRotationY;
    public bool                isShakeRotationZ;
    public bool                isShakeRotation;


    private void Update()
    {
        if (this.isShakePositionX)
        {
            this.isShakePositionX = false;
            this.transform.ShakePositionX(this.positionMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakePositionY)
        {
            this.isShakePositionY = false;
            this.transform.ShakePositionY(this.positionMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakePositionZ)
        {
            this.isShakePositionZ = false;
            this.transform.ShakePositionZ(this.positionMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakePositionXY)
        {
            this.isShakePositionXY = false;
            this.transform.ShakePositionXY(this.positionMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakePosition)
        {
            this.isShakePosition = false;
            this.transform.ShakePosition(this.positionMagnitude, this.speed, this.duration, null);
        }


        if (this.isShakeScaleX)
        {
            this.isShakeScaleX = false;
            this.transform.ShakeScaleX(this.scaleMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeScaleY)
        {
            this.isShakeScaleY = false;
            this.transform.ShakeScaleY(this.scaleMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeScaleZ)
        {
            this.isShakeScaleZ = false;
            this.transform.ShakeScaleZ(this.scaleMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeScaleXY)
        {
            this.isShakeScaleXY = false;
            this.transform.ShakeScaleXY(this.scaleMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeScale)
        {
            this.isShakeScale = false;
            this.transform.ShakeScale(this.scaleMagnitude, this.speed, this.duration, null);
        }


        if (this.isShakeRotationX)
        {
            this.isShakeRotationX = false;
            this.transform.ShakeRotationX(this.rotationMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeRotationY)
        {
            this.isShakeRotationY = false;
            this.transform.ShakeRotationY(this.rotationMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeRotationZ)
        {
            this.isShakeRotationZ = false;
            this.transform.ShakeRotationZ(this.rotationMagnitude, this.speed, this.duration, null);
        }
        else if (this.isShakeRotation)
        {
            this.isShakeRotation = false;
            this.transform.ShakeRotation(this.rotationMagnitude, this.speed, this.duration, null);
        }
    }
}
