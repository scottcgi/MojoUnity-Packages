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
using UnityEditor;
using MojoUnity.Editor;

[CustomEditor(typeof(ObjectTest))]
public class ObjectTestEditor : BaseEditor
{
    protected override DrawType OnProperty(SerializedProperty property, GUIContent lable) 
    {
        switch (property.name)
        {
            case "data":
                switch (property.propertyPath)
                {
                    case "data.data":
                        lable.text = "Data.Data";
                        break;

                    case "data.data.data":
                        lable.text = "Data.Data.Data";
                        break;
                }
                break;

            case "f1":
                switch (property.propertyPath)
                {
                    case "data.f1":
                        lable.text = "F1 - D";
                        break;

                    case "data.data.f1":
                        lable.text = "F1 - DD";
                        break;

                    case "data.data.data.f1":
                        lable.text = "F1 - DDD";
                        return DrawType.GroupBeginTrueNormal;
                }
                break;

            case "f4":
                return DrawType.GroupEndNormal;
        }

        return DrawType.Normal;
    }
}
