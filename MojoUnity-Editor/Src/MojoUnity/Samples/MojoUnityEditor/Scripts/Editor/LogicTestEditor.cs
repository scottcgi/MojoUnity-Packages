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

[CustomEditor(typeof(LogicTest))]
public class LogicTestEditor : BaseEditor
{
    protected override DrawType OnProperty(SerializedProperty property, GUIContent lable) 
    {
        var logicTest = this.target as LogicTest;

        switch (property.name)
        {
            case "value":
                if (logicTest.isShow)
                {
                    return DrawType.IndentOne;
                }
                else
                {
                    return DrawType.None;
                }

            case "f1":
                if (logicTest.hide == LogicTest.Num.One)
                {
                    return DrawType.GroupBeginTrueNone;
                }
                else
                {
                    return DrawType.GroupBeginTrueNormal;
                }
                
            case "f2":
                if (logicTest.hide == LogicTest.Num.Two)
                {
                    return DrawType.None;
                }
                else
                {
                    return DrawType.Normal;
                }

            case "f3":
                if (logicTest.hide == LogicTest.Num.Three)
                {
                    return DrawType.GroupEndNone;
                }
                else
                {
                    return DrawType.GroupEndNormal;
                }

            case "isFoldout":
                logicTest.isFoldout = EditorGUILayout.Foldout(logicTest.isFoldout, "Show", true);

                if (logicTest.isFoldout)
                {
                    return DrawType.GroupBeginTrueNone;
                }
                return DrawType.GroupBeginFalseNone;

            case "ccc":
                return DrawType.GroupEndNormal;
        }

        return DrawType.Normal;
    }
}
