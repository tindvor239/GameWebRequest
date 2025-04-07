using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using GameWebRequest.Data;

using UnityRequestor = GameWebRequest.Unity.Requestor;
using HttpRequestor = GameWebRequest.HttpClients.Requestor;

namespace GameWebRequest.Tests
{
    public class TestPostAPI : MonoBehaviour
    {
        [SerializeField]
        private string url;
        [SerializeField]
        private KeyValuePair<string, string> header = new ("Content-Type", "application/json");

        public async void CallByUnityRequestAsync(object json)
        {
            string jsonData = JsonConvert.SerializeObject(json);
            GameWebRequestResponse response = await UnityRequestor.PostRequest(url, jsonData,
            header);
            Debug.Log($"Response: {response.code} - {response.message} - {response.data}");
        }

        public async void CallByHttpClientAsync(object json)
        {
            string jsonData = JsonConvert.SerializeObject(json);
            Debug.Log(jsonData);
            GameWebRequestResponse response = await HttpRequestor.PostRequest(url, jsonData,
            header);
            Debug.Log($"Response: {response.code} - {response.message} - {response.data}");
        }
    }
}
