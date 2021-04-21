/*
 * Copyright (c) scott.cgi All Rights Reserved.
 * 
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2021-3-18
 * Update : 2021-3-18
 * Author : scott.cgi
 */

using UnityEngine;
using UnityEditor;
using MojoUnity.Editor;

[CustomEditor(typeof(CommonTest))]
public class CommonTestEditor : BaseEditor
{
    protected override DrawType OnProperty(SerializedProperty property, GUIContent lable)
    {
        switch (property.name)
        {
            case "normal":
                return DrawType.Normal;

            case "indentOne":
                return DrawType.IndentOne;

            case "indentTwo":
                return DrawType.IndentTwo;

            case "indentThree":
                return DrawType.IndentThree;

            case "none":
                return DrawType.None;

            case "label":
                lable.text = "My Custom Name";
                break;
        }

        return DrawType.Normal;
    }
}
