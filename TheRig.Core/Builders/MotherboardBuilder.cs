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

        public List<Item> GetCompatibleItems(Motherboard motherboard)
        {
            List<Item> compatible = new List<Item>();
            compatible.AddRange(_unitOfWork.RamRepository.GetCompatible(motherboard));
            compatible.AddRange(_unitOfWork.CpuRepository.GetCompatible(motherboard));
            compatible.AddRange(_unitOfWork.GraphicsRepository.GetCompatible(motherboard));
            compatible.AddRange(_unitOfWork.SoundRepository.GetCompatible(motherboard));

            if (motherboard.Components.Count(x => x.Type == "Ram") == motherboard.MaxRam)
            {
                compatible = compatible.Where(x => x.Type != "Ram").ToList();
            }
            if (motherboard.Components.Count(x => x.Type == "Cpu") == motherboard.MaxCpu)
            {
                compatible = compatible.Where(x => x.Type != "Cpu").ToList();
            }
            if (motherboard.Components.Count(x => x.Type == "Graphic") == motherboard.MaxGraphics)
            {
                compatible = compatible.Where(x => x.Type != "Graphic").ToList();
            }
            if (motherboard.Components.Count(x => x.Type == "Sound") == motherboard.MaxSound)
            {
                compatible = compatible.Where(x => x.Type != "Sound").ToList();
            }
            return compatible;
        }
    }
}
