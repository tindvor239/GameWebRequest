using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using GameWebRequest.Data;

namespace GameWebRequest.HttpClients
{
    public partial class Requestor
    {
        private static readonly HttpClient client = new HttpClient();
        
        public static async UniTask<GameWebRequestResponse> GetRequest(string url)
        {
            return await SendRequest(client.GetAsync(url));
        }

        public static async UniTask<GameWebRequestResponse> PostRequest(string url, string json, KeyValuePair<string, string> header)
        {
            client.DefaultRequestHeaders.Clear();
            // Set the header
            client.DefaultRequestHeaders.Add(header.Key, header.Value);

            // Use StringContent instead of ByteArrayContent for JSON data
            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

            return await SendRequest(client.PostAsync(url, content));
        }

        private static async UniTask<GameWebRequestResponse> SendRequest(Task<HttpResponseMessage> sendRequest)
        {
            float timeStart = Time.time;
            HttpResponseMessage response = await sendRequest;
            response.EnsureSuccessStatusCode();
            float timeEnd = Time.time;
            Debug.Log($"Time http request finished: {timeEnd - timeStart}s");

            if (!response.IsSuccessStatusCode)
            {
                return new GameWebRequestResponse(response.StatusCode, response.ReasonPhrase, default);
            }

            string data = await response.Content.ReadAsStringAsync();
            return new GameWebRequestResponse(response.StatusCode, response.ReasonPhrase, data);
        }
    }
}
