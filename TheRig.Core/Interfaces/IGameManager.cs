
namespace TheRig.Core.Interfaces
{
    public interface IGameManager
    {
        IGameData GameData { get; }
        IGameConfiguration GameConfiguration { get;}
        IGameServices GameServices { get;  }

        void Start();
        void End();
        void Turn();
    }
}
