/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2018-6-7
 * Update : 2020-12-25
 * Author : scott.cgi
 */

using UnityEngine;
using UnityEditor;

namespace MojoUnity.Editor
{
    public abstract class BaseEditorWindow<T1, T2> : EditorWindow where T1 : ScriptableObject where T2 : BaseEditor
    {
        protected T1 scriptableObject;
        protected T2 BaseEditor;

        protected abstract void OnGetPrefs();
        protected abstract void OnSetPrefs();


        public T1 GetScriptableObject()
        {
            return this.scriptableObject;
        }


        protected void OnEnable()
        {
            this.scriptableObject        = ScriptableObject.CreateInstance<T1>();
            this.BaseEditor              = (T2) UnityEditor.Editor.CreateEditor(this.scriptableObject, typeof(T2));
            this.BaseEditor.isShowScript = false;
            this.OnGetPrefs();
        }


        protected void OnGUI()
        {
            this.BaseEditor.OnInspectorGUI();
        }


        protected void OnDisable()
        {
            this.OnSetPrefs();
        }
    }
}

