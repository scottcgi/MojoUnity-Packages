/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2021-3-19
 * Update : 2021-3-19
 * Author : scott.cgi
 */

using MojoUnity.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GroupTest))]
public class GroupTestEditor : BaseEditor
{
    protected override DrawType OnProperty(SerializedProperty property, GUIContent lable)
    {
        var group = this.target as GroupTest;

        switch (property.name)
        {
            case "in1":
                EditorGUILayout.LabelField("Normal Group");
                return DrawType.GroupBeginTrueNormal;

            case "in3":
                return DrawType.GroupEndNormal;

            case "indentGroup":
                EditorGUILayout.Space();
                EditorGUILayout.HelpBox("Custom control insert to properties.", MessageType.Info);
                EditorGUILayout.Space();
                break;

            case "in4":
                EditorGUILayout.LabelField("Indent Group");
                return DrawType.GroupBeginTrueNormal;

            case "in5":
                return DrawType.IndentOne;

            case "in6":
                return DrawType.IndentTwo;

            case "in7":
                return DrawType.GroupEndIndentThree;

            case "isFoldout":
                group.isFoldout = EditorGUILayout.Foldout(group.isFoldout, "Foldout Group", true);
                return DrawType.None;

            case "in8":
                if (group.isFoldout)
                {
                    return DrawType.GroupBeginTrueNormal;
                }
                else
                {
                    return DrawType.GroupBeginFalseNone;
                }

            case "in10":
                return DrawType.GroupEndNormal;

            case "in11":
                EditorGUILayout.LabelField("Nested Group");
                return DrawType.GroupBeginTrueNormal;

            case "in16":
                return DrawType.GroupEndNormal;

            case "in12":
                return DrawType.GroupBeginTrueNormal;

            case "in15":
                return DrawType.GroupEndNormal;

            case "in13":
                return DrawType.GroupBeginTrueNormal;

            case "in14":
                return DrawType.GroupEndNormal;
        }

        return DrawType.Normal;
    }


    protected override void OnAfterProperty(SerializedProperty property)
    {
        if (property.name == "in16")
        {
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("After property in16.", MessageType.Info);
        }
    }
}
