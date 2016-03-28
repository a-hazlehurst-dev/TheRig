using TheRig.Core.Configuration;

namespace TheRig.Core.Interfaces.Configuration
{
    public interface IGameSetupConfiguration
    {
        SoundConfiguration Sound { get; set; }
        GraphicsConfiguration Graphics { get; set; }
        DataConfiguration Data { get; set; }
    }
}
