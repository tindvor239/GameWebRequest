using UnityEngine;

namespace GameWebRequest.Tests
{
    public class TestGetAPI : MonoBehaviour
    {
        [SerializeField]
        private string url;

        private async void Start()
        {
            var result = await Unity.Requestor.GetRequest(url);

            // var result = await Http.HttpRequestor.GetByHttpClient(url,
            // error =>
            //     {
            //         Debug.LogError($"Request failed: {error.Message}");
            //     });

            // var result = await Http.HttpRequestor.GetByBestHttp(url,
            // error =>
            //     {
            //         Debug.LogError($"Request failed: {error.Message}");
            //     });
        }
    }
}
