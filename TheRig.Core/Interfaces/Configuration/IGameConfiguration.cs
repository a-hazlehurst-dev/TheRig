using TheRig.Core.Interfaces.Configuration;

namespace TheRig.Core.Interfaces
{
    public interface IGameConfiguration
    {
        IGameSetupConfiguration GameSetupConfiguration { get; set; }
        IGameplayConfiguration GameplayConfiguration { get; set; }
    }
}
