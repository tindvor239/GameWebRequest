using System.Net;
using System.Text;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UniRx;
using Cysharp.Threading.Tasks;
using GameWebRequest.Data;

namespace GameWebRequest.Unity
{
    public partial class Requestor
    {
        public static async UniTask<GameWebRequestResponse> GetRequest(string url)
        {
            UnityWebRequest request = UnityWebRequest.Get(url);
            return await SendRequest(request);
        }

        public static async UniTask<GameWebRequestResponse> PostRequest(string url, string json, KeyValuePair<string, string> header)
        {
            UnityWebRequest request = new UnityWebRequest(url, "POST");
            byte[] bodyRaw = Encoding.UTF8.GetBytes(json);// Chuyển JSON thành byte array
            request.uploadHandler = new UploadHandlerRaw(bodyRaw); // Gán dữ liệu vào body
            request.downloadHandler = new DownloadHandlerBuffer(); // Để nhận phản hồi từ server
            request.SetRequestHeader(header.Key, header.Value);

            return await SendRequest(request);
        }

        private static async UniTask<GameWebRequestResponse> SendRequest(UnityWebRequest request)
        {
            float timeStart = Time.time;
            await request.SendWebRequest();
            float timeEnd = Time.time;
            Debug.Log($"Time http POST request finished: {timeEnd - timeStart}s");

            if (request.result == UnityWebRequest.Result.ConnectionError ||
                request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError($"Request Error: {request.error}");
                return new GameWebRequestResponse((HttpStatusCode)request.responseCode, request.error, default);
            }

            var jsonResponse = request.downloadHandler.text;
            return new GameWebRequestResponse((HttpStatusCode)request.responseCode, request.error, jsonResponse);
        }
    }
}