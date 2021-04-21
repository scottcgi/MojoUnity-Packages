/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2021-3-20
 * Update : 2021-3-20
 * Author : scott.cgi
 */

using System;
using UnityEngine;

public class ArrayTest : MonoBehaviour
{
    public string[] strs;
    public Data1 [] datas;

    [Serializable]
    public struct Data1
    {
        public Data2[] datas;
    }

    [Serializable]
    public struct Data2
    {
        public string[] strs;
    }
}
