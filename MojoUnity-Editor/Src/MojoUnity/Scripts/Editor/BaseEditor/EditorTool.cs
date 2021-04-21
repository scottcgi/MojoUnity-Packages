/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2017-11-13
 * Update : 2020-2-10
 * Author : scott.cgi
 */

using UnityEditor;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

namespace MojoUnity.Editor
{
    public static class EditorTool
    {
        private static readonly GUIStyle handleStyle;
        public  static readonly GUIStyle boxScopeStyle;


        static EditorTool()
        {
            handleStyle                  = new GUIStyle();
            handleStyle.fontStyle        = FontStyle.Bold;
            handleStyle.fontSize         = 14;
            handleStyle.normal.textColor = Color.white;

            boxScopeStyle                = new GUIStyle(GUI.skin.box);
            var padding                  = boxScopeStyle.padding;
            padding.right               += 6;
            padding.top                 += 1;
            padding.left                += 3;
        }


        /// <summary>
        /// Show transform handle in scene and register undo handle changed.
        /// return new position if handle moved.
        /// </summary>
        public static void ShowHandle(Transform transform)
        {
            var pos = transform.position;
            Handles.Label(pos, $"{transform.name}({pos.x}, {pos.y}, {pos.z})", handleStyle);

            EditorGUI.BeginChangeCheck();

            pos = Handles.PositionHandle(pos, transform.rotation);

            if (EditorGUI.EndChangeCheck())
            {
                pos.x = Mathf.Floor(pos.x); 
                pos.y = Mathf.Floor(pos.y);
                pos.z = Mathf.Floor(pos.z); 

                Undo.RecordObject(transform, "Transform handle changed");
                transform.position = pos;
            }
        }


        /// <summary>
        /// Show position handle in scene.
        /// [OnChaned]: when handle changed callback, and give the new position.
        /// </summary>
        public static void ShowHandle(Vector3 position, string handleName, Action<Vector3> OnChanged)
        {
            Handles.Label
            (
                position,
                $"{handleName}({position.x}, {position.y}, {position.z})",
                handleStyle
            );

            EditorGUI.BeginChangeCheck();

            position = Handles.PositionHandle(position, Quaternion.identity);

            if (EditorGUI.EndChangeCheck())
            {
                position.x = Mathf.Floor(position.x);
                position.y = Mathf.Floor(position.y);
                position.z = Mathf.Floor(position.z);

                OnChanged(position);
            }
        }


        /// <summary>
        /// Get the property index from propertyPath.
        /// e.g. Array.data[0].propertyName return 0.
        /// If property not have Array return -1.
        /// </summary>
        public static int GetPropertyIndex(SerializedProperty property)
        {
            var path = property.propertyPath;
            var last = path.LastIndexOf(']');

            if (last == -1)
            {
                return -1;
            }

            var start    = path.LastIndexOf('[', last - 2);
            var indexStr = path.Substring(start + 1, last - start - 1);

            return int.Parse(indexStr);
        }


        /// <summary>
        /// Get the property each indexes from propertyPath.
        /// e.g. Array.data[0].obj.Array.data[1].propertyName return {0, 1}.
        /// If property not have any Arrays return null.
        /// </summary>
        public static int[] GetPropertyIndexPath(SerializedProperty property)
        {
            var matches = Regex.Matches(property.propertyPath, @"Array\.data\[(\d+)\]");
            var count   = matches.Count;

            if (count > 0)
            {
                var indexes = new int[count];
                for (var i = 0; i < count; ++i)
                {
                    indexes[i] = int.Parse(matches[i].Groups[1].Value);
                }

                return indexes;
            }

            return null;
        }
    }
}

