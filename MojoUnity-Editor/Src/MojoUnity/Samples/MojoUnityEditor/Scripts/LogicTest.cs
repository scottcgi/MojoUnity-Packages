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

using UnityEngine;

public class LogicTest : MonoBehaviour
{
    public bool   isShow;
    public float  value;
    public Num    hide;
    [Range(0, 100)]
    public int    f1;
    public Color  f2;
    public Object f3;

    #if UNITY_EDITOR
    public bool   isFoldout;
    #endif

    public string aaa;
    public string bbb;
    public string ccc;

    public enum Num
    {
        One,
        Two,
        Three,
    }
}
