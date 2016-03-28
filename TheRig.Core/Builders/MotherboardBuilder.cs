using TheRig.Core.Interfaces;

namespace TheRig.Core.Builders
{
    public class MotherboardBuilder
    {
        private IGameData _gameData;
        public MotherboardBuilder(IGameData gameData)
        {
            _gameData = gameData;
        }
    }
}
