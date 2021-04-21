/*
 * Copyright (c) scott.cgi All Rights Reserved.
 *
 * This source code belongs to project MojoUnity-Packages, which is hosted on GitHub, and licensed under the MIT License.
 *
 * License: https://github.com/scottcgi/MojoUnity-Packages/blob/main/LICENSE
 * GitHub : https://github.com/scottcgi/MojoUnity-Packages
 * Package: https://github.com/scottcgi/MojoUnity-Packages/tree/main/MojoUnity-Editor
 *
 * Since  : 2021-3-23
 * Update : 2021-3-23
 * Author : scott.cgi
 */

using MojoUnity.Editor;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WindowTest))]
public class WindowTestEditor : BaseEditor
{
    public override void OnInspectorGUI()
    {
        GUILayout.Space(20);

        if(GUILayout.Button("Open Default Win"))
        {
            var win     = EditorWindow.GetWindow<DefaultWindow>(true, "Default Win", true);
            win.minSize = new Vector2(350, 100);
            win.maxSize = new Vector2(350, 100);
            win.Show();
        }

        EditorGUILayout.Space();

        if(GUILayout.Button("Open Extended Win"))
        {
            var win     = EditorWindow.GetWindow<ExtendedConfigWindow>(false, "Extended Win", false);
            win.minSize = new Vector2(400, 230);
            win.maxSize = new Vector2(400, 230);
            win.Show();
        }

        GUILayout.Space(20);
    }


    #region Default Win
    public class DefaultConfig : ScriptableObject
    {
        public string aaa;
        public string bbb;
        public string ccc;
        [Range(0, 100)]
        public int    ddd;
    }


    public class DefaultWindow : BaseEditorWindow<DefaultConfig, BaseEditor.DefaultEditor>
    {
        private const string DefaultWindowKey = "DefaultWindowKey";


        protected override void OnGetPrefs()
        {
            var value = EditorPrefs.GetString(DefaultWindowKey);

            if (value != "")
            {
                var values = value.Split(',');
                this.scriptableObject.aaa = values[0];
                this.scriptableObject.bbb = values[1];
                this.scriptableObject.ccc = values[2];
                this.scriptableObject.ddd = int.Parse(values[3]);
            }
        }


        protected override void OnSetPrefs()
        {
            var value = this.scriptableObject.aaa + "," +
                        this.scriptableObject.bbb + "," +
                        this.scriptableObject.ccc + "," +
                        this.scriptableObject.ddd;

            EditorPrefs.SetString(DefaultWindowKey, value);
        }
    }
    #endregion


    #region Extended Win
    private class ExtendedConfig : ScriptableObject
    {
        public string label;
    }


    private class ExtendedEditor : BaseEditor
    {
        protected override void OnAfterProperty(SerializedProperty property)
        {
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal(GUI.skin.box);
            EditorGUILayout.LabelField("Horizontal", GUILayout.MaxWidth(80));
            EditorGUILayout.LabelField("X",          GUILayout.MaxWidth(20));
            EditorGUILayout.FloatField(11.1f,        GUILayout.MaxWidth(80));
            EditorGUILayout.LabelField("Y",          GUILayout.MaxWidth(20));
            EditorGUILayout.IntField  (100,          GUILayout.MaxWidth(80));
            EditorGUILayout.LabelField("T",          GUILayout.MaxWidth(20));
            EditorGUILayout.TextField ("text",       GUILayout.MaxWidth(80));
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(GUI.skin.box);
            EditorGUILayout.ColorField("ColorField", Color.red);
            EditorGUILayout.CurveField("CurveField", new AnimationCurve());
            EditorGUILayout.Slider("Slider", 50, 0, 100);
            EditorGUILayout.Space();
            EditorGUILayout.HelpBox("HelpBox", MessageType.Info);
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            GUILayout.Button("Btn1");
        }
    }


    private class ExtendedConfigWindow : BaseEditorWindow<ExtendedConfig, ExtendedEditor>
    {
        protected override void OnGetPrefs()
        {
            // EditorPrefs.GetString(key);
        }


        protected override void OnSetPrefs()
        {
            // EditorPrefs.SetString(key, value);
        }
    }
    #endregion

}
