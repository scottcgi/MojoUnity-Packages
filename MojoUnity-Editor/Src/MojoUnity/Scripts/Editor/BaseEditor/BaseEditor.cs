/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2017-9-27
 * Update : 2021-3-22
 * Author : scott.cgi
 */

using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System;

namespace MojoUnity.Editor
{
    public abstract class BaseEditor : UnityEditor.Editor
    {
        #region Public
        /// <summary>
        /// Property draw type.
        /// </summary>
        public enum DrawType
        {
            /// <summary>
            /// Not drawing.
            /// </summary>
            None,

            /// <summary>
            /// Draw without indent.
            /// </summary>
            Normal,

            /// <summary>
            /// Draw with one indent level.
            /// </summary>
            IndentOne,

            /// <summary>
            /// Draw with two indent level.
            /// </summary>
            IndentTwo,

            /// <summary>
            /// Draw with three indent level.
            /// </summary>
            IndentThree,            

            /// <summary>
            /// Mark group begin, the foldout is true, and this property is None.
            /// </summary>
            GroupBeginTrueNone,

            /// <summary>
            /// Mark group begin, the foldout is true, and this property is Normal.
            /// </summary>
            GroupBeginTrueNormal,

            /// <summary>
            /// Mark group begin, the foldout is true, and this property is IndentOne.
            /// </summary>
            GroupBeginTrueIndentOne,

            /// <summary>
            /// Mark group begin, the foldout is true, and this property is IndentTwo.
            /// </summary>
            GroupBeginTrueIndentTwo,

            /// <summary>
            /// Mark group begin, the foldout is true, and this property is IndentThree.
            /// </summary>
            GroupBeginTrueIndentThree,

            /// <summary>
            /// Mark group begin, the foldout is false, and this property is None.
            /// </summary>
            GroupBeginFalseNone,

            /// <summary>
            /// Mark group end, and this property is None.
            /// </summary>
            GroupEndNone,

            /// <summary>
            /// Mark group end, and this property is Normal.
            /// </summary>
            GroupEndNormal,

            /// <summary>
            /// Mark group end, and this property is IndentOne.
            /// </summary>
            GroupEndIndentOne,

            /// <summary>
            /// Mark group end, and this property is IndentTwo.
            /// </summary>
            GroupEndIndentTwo,

            /// <summary>
            /// Mark group end, and this property is IndentThree.
            /// </summary>
            GroupEndIndentThree,
        }

        /// <summary>
        /// Default BaseEditor.
        /// </summary>
        public sealed class DefaultEditor : BaseEditor { }

        /// <summary>
        /// Whether show the disabled script property ?
        /// </summary>
        public bool isShowScript = true;
        #endregion


        #region Protected
        /// <summary>
        /// Handle property in target.
        /// Set the label will display on property.
        /// </summary>
        protected virtual DrawType OnProperty(SerializedProperty property, GUIContent lable) 
        {
            return DrawType.Normal;
        }


        /// <summary>
        /// Callback when the property is drawn.
        /// Usually used for custom drawing after property display.
        /// </summary>
        protected virtual void OnAfterProperty(SerializedProperty property) { }
        #endregion


        #region Callback
        protected virtual void OnEnable()
        {
            this.propertyLabel   = new GUIContent();
            this.groupBeginStack = new Stack<bool>(6);

            try
            {
                this.arrayStyle        = EditorStyles.helpBox;
                this.arrayFoldoutStyle = EditorStyles.foldout; 
                this.groupStyle        = EditorStyles.helpBox;
            }
            catch (NullReferenceException)
            {
                // fix recompile error
            }

            var iterator = this.serializedObject.GetIterator();

            // go to child
            iterator.NextVisible(true);

            if (this.isShowScript)
            {
                this.scriptProperty = iterator.Copy();
            }

            this.firstProperty = iterator;
        }


        public override void OnInspectorGUI()
        {
            this.serializedObject.UpdateIfRequiredOrScript();

            if (this.isShowScript)
            {
                // draw disabled script
                GUI.enabled = false;
                EditorGUILayout.PropertyField(this.scriptProperty);
                GUI.enabled = true;
            }

            // get new iterator
            var iterator = this.firstProperty.Copy();

            // skip property with [HideInInspector]
            while (iterator.NextVisible(false))
            {
                // copy reference
                var property = iterator.Copy();
                this.DrawProperty(property);
            }

            this.serializedObject.ApplyModifiedProperties();
        }
        #endregion


        #region Private
        /// <summary>
        /// For custom array vertical style.
        /// </summary>
        private GUIStyle           arrayStyle;

        /// <summary>
        /// For custom array foldout style.
        /// </summary>
        private GUIStyle           arrayFoldoutStyle;

        /// <summary>
        /// For custom group vertical style.
        /// </summary>
        private GUIStyle           groupStyle;

        /// <summary>
        /// The label of the property display.
        /// Auto reset after property used.
        /// </summary>
        private GUIContent         propertyLabel;
                                                 
        /// <summary>                            
        /// The first property for iterator.     
        /// </summary>                           
        private SerializedProperty firstProperty;
                                                 
        /// <summary>                            
        /// The mono script property.            
        /// </summary>                           
        private SerializedProperty scriptProperty;

        /// <summary>
        /// Record begin of property group.
        /// </summary>
        private Stack<bool>        groupBeginStack;


        /// <summary>
        /// Draw the array.
        /// </summary>
        private void DrawArray(SerializedProperty arrayProperty)
        {
            arrayProperty.isExpanded = EditorGUILayout.Foldout
                                       (
                                           arrayProperty.isExpanded,
                                           this.propertyLabel,
                                           true,
                                           this.arrayFoldoutStyle
                                       );

            if (EditorGUILayout.BeginFadeGroup(arrayProperty.isExpanded ? 1.0f : 0.0f))
            {
                ++EditorGUI.indentLevel;
                var arraySize           = arrayProperty.arraySize;
                arrayProperty.arraySize = EditorGUILayout.DelayedIntField("Array Size", arraySize);

                // wait for array target expansion or array length may less than arraySize
                if (arraySize == arrayProperty.arraySize)
                {
                    for (int i = 0, size = arrayProperty.arraySize; i < size; ++i)
                    {
                        var elementProperty = arrayProperty.GetArrayElementAtIndex(i);
                        EditorGUILayout.PropertyField(elementProperty, false);

                        if (elementProperty.hasChildren) 
                        {
                            this.DrawObject(elementProperty, true);
                        }
                    }
                }
                --EditorGUI.indentLevel;
            }
            EditorGUILayout.EndFadeGroup();
        }


        /// <summary>
        /// Draw the object.
        /// </summary>
        private void DrawObject(SerializedProperty objectProperty, bool isGroup)
        {
            if (EditorGUILayout.BeginFadeGroup(objectProperty.isExpanded ? 1.0f : 0.0f))
            {
                if (isGroup)
                {
                    EditorGUILayout.BeginVertical(this.arrayStyle);
                }

                ++EditorGUI.indentLevel;
                var iterator    = objectProperty.Copy();
                var parentDepth = iterator.depth;
                // go to child
                iterator.NextVisible(true);

                // iterator objectProperty children
                while (iterator.depth > parentDepth)
                {
                    // use copy reference
                    this.DrawProperty(iterator.Copy());

                    if (iterator.NextVisible(false) == false)
                    {
                        break;
                    }
                }
                --EditorGUI.indentLevel;

                if (isGroup)
                {
                    EditorGUILayout.EndVertical();
                }
            }
            EditorGUILayout.EndFadeGroup();
        }


        /// <summary>
        /// Draw the property.
        /// </summary>
        private void DrawProperty(SerializedProperty property)
        {
            // clear for OnProperty to setting
            this.ClearLabel();
            var drawType = this.OnProperty(property, this.propertyLabel);

            switch (drawType)
            {
                case DrawType.GroupBeginFalseNone:
                    // start group and foldout is false
                    this.groupBeginStack.Push(false);
                    break;

                case DrawType.GroupBeginTrueNone:
                case DrawType.GroupBeginTrueNormal:
                case DrawType.GroupBeginTrueIndentOne:
                case DrawType.GroupBeginTrueIndentTwo:
                case DrawType.GroupBeginTrueIndentThree:
                    // start group and foldout is true
                    this.groupBeginStack.Push(true);
                    ++EditorGUI.indentLevel;
                    EditorGUILayout.BeginVertical(this.groupStyle);
                    // draw first in group
                    this.DrawPropertyByDrawType(property, drawType);
                    break;

                case DrawType.GroupEndNone:
                case DrawType.GroupEndNormal:
                case DrawType.GroupEndIndentOne:
                case DrawType.GroupEndIndentTwo:
                case DrawType.GroupEndIndentThree:
                    if (this.groupBeginStack.Peek())
                    {
                        // draw last in group
                        this.DrawPropertyByDrawType(property, drawType);
                        EditorGUILayout.EndVertical();
                        --EditorGUI.indentLevel;
                    }
                    this.groupBeginStack.Pop();
                    break;

                case DrawType.None:
                    break;

                default:
                    this.DrawPropertyByDrawType(property, drawType);
                    break;
            }

            this.OnAfterProperty(property);
        }


        /// <summary>
        /// Draw the property by drawType.
        /// </summary>
        private void DrawPropertyByDrawType(SerializedProperty property, DrawType drawType)
        {
            // property is group
            if (this.groupBeginStack.Count > 0)
            {
                // GroupBeginFalse
                if (this.groupBeginStack.Peek() == false)
                {
                    return;
                }

                // convert group drawType to property drawType
                switch (drawType)
                {
                    case DrawType.GroupBeginTrueNone:
                    case DrawType.GroupEndNone:
                        drawType = DrawType.None;
                        break;

                    case DrawType.GroupBeginTrueNormal:
                    case DrawType.GroupEndNormal:
                        drawType = DrawType.Normal;
                        break;

                    case DrawType.GroupBeginTrueIndentOne:
                    case DrawType.GroupEndIndentOne:
                        drawType = DrawType.IndentOne;
                        break;

                    case DrawType.GroupBeginTrueIndentTwo:
                    case DrawType.GroupEndIndentTwo:
                        drawType = DrawType.IndentTwo;
                        break;

                    case DrawType.GroupBeginTrueIndentThree:
                    case DrawType.GroupEndIndentThree:
                        drawType = DrawType.IndentThree;
                        break;
                }
            }

            var indentLevel = 0;

            switch (drawType)
            {
                case DrawType.Normal:
                    break;

                case DrawType.IndentOne:
                    indentLevel = 1;
                    break;

                case DrawType.IndentTwo:
                    indentLevel = 2;
                    break;

                case DrawType.IndentThree:
                    indentLevel = 3;
                    break;

                default:
                    return;
            }

            EditorGUI.indentLevel += indentLevel;
            // check before draw property
            this.CheckLabel(property);

            if (property.isArray)
            {
                if (property.arrayElementType != "char")
                {
                    this.DrawArray(property);
                }
                else
                {
                    // just string field
                    EditorGUILayout.PropertyField(property, this.propertyLabel, false);
                }
            }
            else
            {
                EditorGUILayout.PropertyField(property, this.propertyLabel, false);

                if (property.hasChildren)
                {
                    this.DrawObject(property, false);
                }
            }
            EditorGUI.indentLevel -= indentLevel;
        }


        /// <summary>
        /// Clear the label.
        /// </summary>
        private void ClearLabel()
        {
            this.propertyLabel.image   = null;
            this.propertyLabel.text    = "";
            this.propertyLabel.tooltip = "";
        }


        /// <summary>
        /// Check label whether need to set default name.
        /// </summary>
        private void CheckLabel(SerializedProperty property)
        {
            if (this.propertyLabel.text == "")
            {
                this.propertyLabel.text = property.displayName;
            }
        }
        #endregion
    }
}

