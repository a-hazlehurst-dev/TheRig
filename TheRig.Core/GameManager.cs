
using TheRig.Core.Interfaces;
using TheRig.Models.Components;

namespace TheRig.Core
{
    public class GameManager
    {
       
        public IUnitOfWork UnitOfWork { get; private set; }

        public GameManager( IUnitOfWork unitOfWork)
        {
           
            UnitOfWork = unitOfWork;
        }


        public Motherboard GetMotherboard(int id)
        {
            return UnitOfWork.MotherboardRepository.GetMotherboard(id);
        }
    }
}
