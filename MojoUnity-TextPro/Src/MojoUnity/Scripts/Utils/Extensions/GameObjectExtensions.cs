/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: Shared by multiple packages
 *
 * Since  : 2017-8-21
 * Update : 2021-1-12
 * Author : scott.cgi
 */

using System;
using UnityEngine;
using UnityEngine.UI;

namespace MojoUnity
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// Parent add child from new GameObject and add T Component
        /// [isWorldStays]: Whether keep world space position, rotation, scale as before.
        /// </summary>
        public static T AddChild<T>(this GameObject parent, bool isWorldStays = false) where T : Component
        {
            var child = new GameObject();
            child.transform.SetParent(parent.transform, isWorldStays);

            return child.AddComponent<T>();
        }
        

        /// <summary>
        /// GameObject add image and set sprite.
        /// </summary>
        public static Image AddImage(this GameObject go, Sprite sprite)
        {
            var image    = go.AddComponent<Image>();
            image.sprite = sprite;

            return image;
        }
    }
}

