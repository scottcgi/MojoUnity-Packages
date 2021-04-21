/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2021-3-22
 * Update : 2021-3-22
 * Author : scott.cgi
 */

using System;
using UnityEngine;

public class ObjectTest : MonoBehaviour
{
    public int   f1;
    public Data1 data;


    [Serializable]
    public struct Data1
    {
        public int    f1;
        public string s1;
        public Data2  data;
    }


    [Serializable]
    public struct Data2
    {
        public int   f1;
        public Data3 data;
    }


    [Serializable]
    public struct Data3
    {
        public int f1;
        public int f2;
        [HideInInspector]
        public int f3;
        public int f4;
    }
}