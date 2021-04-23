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

using System.Collections;
using UnityEngine;

public class CoroutineExecutor : MonoBehaviour
{
    private static CoroutineExecutor instance;

    private void Start()
    {
        instance = this;
    }

    /// <summary>
    /// Start a coroutine task.
    /// </summary>
    public static Coroutine StartTask(IEnumerator routine)
    {
        return instance.StartCoroutine(routine);
    }
}
