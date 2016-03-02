using System.Collections.Generic;
using System.Linq;
using TheRig.Core.Interfaces;
using TheRig.Models.Components;

namespace TheRig.Core.Builders
{
    public class MotherboardBuilder
    {
        private IUnitOfWork _unitOfWork;
        public MotherboardBuilder(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

      
    }
}
