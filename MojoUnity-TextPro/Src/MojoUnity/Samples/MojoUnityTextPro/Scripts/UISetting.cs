/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-TextPro
 *
 * Since  : 2021-6-5
 * Update : 2021-6-5
 * Author : scott.cgi
 */

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UISetting : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.AddComponent<GraphicRaycaster>();
        this.gameObject.AddComponent<EventSystem>();
        this.gameObject.AddComponent<StandaloneInputModule>();    
    }
}
