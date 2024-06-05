using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace GV.Extensions
{
    [System.Serializable]
    public class SceneField
    {
        [SerializeField]
        private Object _sceneAsset;

        [SerializeField]
        private string _sceneName = "";

        public string SceneName
        {
            get { return _sceneName; }
        }

        //make it work with existing Unity methods (LoadLevel/LoadScene)
        public static implicit operator string(SceneField sceneField)
        {
            return sceneField.SceneName;
        }
    }

#if UNITY_EDITOR
    [CustomPropertyDrawer(typeof(SceneField))]
    public class SceneFieldPropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            EditorGUI.BeginProperty(position, GUIContent.none, property);

            SerializedProperty sceneAsset = property.FindPropertyRelative("_sceneAsset");
            SerializedProperty sceneName = property.FindPropertyRelative("_sceneName");

            position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
            if (sceneAsset != null)
            {
                sceneAsset.objectReferenceValue = EditorGUI.ObjectField(position, sceneAsset.objectReferenceValue, typeof(SceneAsset), false);

                if (sceneAsset.objectReferenceValue != null)
                    sceneName.stringValue = (sceneAsset.objectReferenceValue as SceneAsset).name;
            }

            EditorGUI.EndProperty();
        }
    }
#endif
}
