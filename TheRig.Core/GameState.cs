using System;

namespace TheRig.Core
{
    public class GameState
    {
        private static GameState _instance;

        public static GameState Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GameState();
                    _instance.Player = new Player();
                }
                return _instance;
            }
        }   

        public  DateTime GameTime { get; set; }       
        public  Player Player { get; set; }

        private  GameState(){
            
        }
    }

}
