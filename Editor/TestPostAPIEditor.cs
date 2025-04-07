using UnityEditor;
using UnityEngine;
using GameWebRequest.Tests;
using GameWebRequest.Data;

namespace GameWebRequest.Editor
{
    /// <summary>
    /// Custom editor for the TestPostAPI class, allowing for easy testing of POST requests from the Unity Editor.
    /// </summary>
    [CustomEditor(typeof(TestPostAPI))]
    public class TestPostAPIEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            TestPostAPI testPostAPI = (TestPostAPI)target;
            EditorGUILayout.BeginHorizontal("box");
            if (GUILayout.Button("Send Unity Post Request"))
            {
                var json = GetDeviceID();
                testPostAPI.CallByUnityRequestAsync(json);
            }

            if (GUILayout.Button("Send HttpClient Post Request"))
            {
                var json = GetDeviceID();
                testPostAPI.CallByHttpClientAsync(json);
            }
            EditorGUILayout.EndVertical();
        }

        private PlayerProfile GetDeviceID()
        {
            return new PlayerProfile(SystemInfo.deviceUniqueIdentifier);
        }
    }
}
