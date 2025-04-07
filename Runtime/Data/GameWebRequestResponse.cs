using System.Net;

namespace GameWebRequest.Data
{
    /// <summary>
    /// Represents a response structure for web requests in the game.
    /// Contains status code, message, and data from the server response.
    /// </summary>
    public struct GameWebRequestResponse
    {
        /// <summary>
        /// The HTTP status code of the response
        /// </summary>
        public readonly HttpStatusCode code;

        /// <summary>
        /// The message associated with the response (e.g., error description or success message)
        /// </summary>
        public readonly string message;

        /// <summary>
        /// The data payload returned from the server
        /// </summary>
        public readonly string data;

        /// <summary>
        /// Initializes a new instance of the GameWebRequestResponse structure
        /// </summary>
        /// <param name="code">The HTTP status code</param>
        /// <param name="message">The response message</param>
        /// <param name="data">The response data payload</param>
        public GameWebRequestResponse(HttpStatusCode code, string message, string data)
        {
            this.code = code;
            this.message = message;
            this.data = data;
        }

        /// <summary>
        /// Returns a string representation of the response
        /// </summary>
        /// <returns>A formatted string containing the code, message, and data</returns>
        public override string ToString()
        {
            return $"Code: {code}, Message: {message}, Data: {data}";
        }
    }
}