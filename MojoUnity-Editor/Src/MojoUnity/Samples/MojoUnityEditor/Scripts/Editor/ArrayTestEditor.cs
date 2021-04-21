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

using UnityEngine;
using UnityEditor;
using MojoUnity.Editor;

[CustomEditor(typeof(ArrayTest))]
public class ArrayTestEditor : BaseEditor
{
    protected override DrawType OnProperty(SerializedProperty property, GUIContent lable)
    {
        switch (property.name)
        {
            case "datas":
                var index = EditorTool.GetPropertyIndex(property);
                if (index != -1)
                {
                    lable.text = $"datas - {index}";
                }
                break;

            case "strs":
                var indexes = EditorTool.GetPropertyIndexPath(property);
                if (indexes != null)
                {
                    lable.text = $"strs - {indexes[0]} - {indexes[1]}";
                }
                break;
        }

        return DrawType.Normal;
    }
}
