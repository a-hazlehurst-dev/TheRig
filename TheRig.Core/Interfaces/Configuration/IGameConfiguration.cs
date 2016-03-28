

using TheRig.Core.Configuration;

namespace TheRig.Core.Interfaces
{
    public interface IGameConfiguration
    {
        /// <summary>
        /// Contains global config settings for the game.
        /// </summary>
        GameSetupConfiguration GameSetupConfiguration { get; set; }
        /// <summary>
        /// Contains settings for a specific game.
        /// </summary>
        GameplayConfiguration GameplayConfiguration { get; set; }
    }
}
