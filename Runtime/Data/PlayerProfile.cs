namespace GameWebRequest.Data
{
    /// <summary>
    /// Represents a player profile structure for web requests in the game.
    /// Contains the device ID of the player.
    /// </summary>
    public class PlayerProfile
    {
        /// <summary>
        /// The unique identifier for the device
        /// </summary>
        public readonly string deviceId;

        /// <summary>
        /// Initializes a new instance of the PlayerProfile class
        /// </summary>
        /// <param name="deviceId">The unique identifier for the device</param>
        /// <remarks>
        /// This constructor sets the deviceId property to the provided value.
        /// </remarks>
        public PlayerProfile(string deviceId)
        {
            this.deviceId = deviceId;
        }
    }
}