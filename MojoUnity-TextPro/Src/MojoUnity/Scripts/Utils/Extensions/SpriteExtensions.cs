/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: Shared by multiple packages
 *
 * Since  : 2020-12-31
 * Update : 2021-6-5
 * Author : scott.cgi
 */

using UnityEngine;

namespace MojoUnity
{
    public static class SpriteExtensions
    {
        /// <summary>
        /// Get ratio size by max width and height with rect scale.
        /// </summary>
        public static Vector2 GetRatioSizeByMax(this Sprite sprite, float maxWidth, float maxHeight, float scale = 1.0f)
        {
            var rect   = sprite.rect;
            var width  = rect.width  * scale;
            var height = rect.height * scale;

            if (width >= height)
            {
                if (width > maxWidth)
                {
                    // height becomes small
                    height *= maxWidth / width;
                    // width becoms small
                    width   = maxWidth;
                }

                if (height > maxHeight)
                {
                    // width also becoms smaller
                    width *= maxHeight / height;
                    // height becomes smalller
                    height = maxHeight;
                }
            }
            else
            {
                if (height > maxHeight)
                {
                    // width becoms small
                    width *= maxHeight / height;
                    // height becomes small
                    height = maxHeight;
                }

                if (width > maxWidth)
                {
                    // height becomes smaller
                    height *= maxWidth / width;
                    // width becomes smaller
                    width   = maxWidth;
                }
            }

            return new Vector2(width, height);
        }
    }
}

