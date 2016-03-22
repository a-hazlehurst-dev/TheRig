using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TheRig.Core.Configuration;

namespace TheRig.Core.Interfaces
{
    public interface IGameManager
    {
        GamePreferences GameConfiguration { get; set; }
        GlobalState GlobalState { get; set; }
        IGameState GameState { get; set; }

        void Initialise(IDataProvider dataProvider);
        void Start();
        void End();
    }

 
    public interface IGameState
    {

        List<Player> Players { get; set; }
        void Initialise();
        void Turn();
    }

    
}
