/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2020-6-29
 * Update : 2020-6-29
 * Author : scott.cgi
 */

using UnityEditor;
using UnityEngine;

namespace MojoUnity.Editor
{
    /// <summary>
    /// Disabled the PropertyField.
    /// </summary>
    [CustomPropertyDrawer(typeof(CannotEditableAttribute))]
    public class CannotEditableDrawer : PropertyDrawer
    {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUI.GetPropertyHeight(property, label, true);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginDisabledGroup(true);
            EditorGUI.PropertyField(position, property, label, true);
            EditorGUI.EndDisabledGroup();
        }
    }
}
